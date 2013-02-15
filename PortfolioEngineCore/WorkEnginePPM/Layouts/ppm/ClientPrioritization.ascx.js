function ClientPrioritization(thisID, clientID, Path, Webservice) {
    // NB Constructor code at end of function
    var MakeDelegate = function (target, method) {
        if (method == null) {
            throw ("Method not found");
        }

        return function () {
            return method.apply(target, arguments);
        }
    }


    ClientPrioritization.prototype.OnLoad = function (event) {

        WorkEnginePPM.ClientPrioritization.set_path(this.Webservice);
        WorkEnginePPM.ClientPrioritization.GetClientPrioritizationData(GetClientPrioritizationDataDelegate);
    }

    ClientPrioritization.prototype.OnUnload = function (event) {
        if (this.Dirty)
            return "You have unsaved changes.\n\nAre you sure you want to exit without saving?";
    }

    ClientPrioritization.prototype.OnResize = function (event) {
        var divLayout = document.getElementById(this.clientID + "layoutDiv");
        if (this.initialized == true) {
            var toolbarDataObjectDiv = document.getElementById("toolbarDataObjectDiv");
            var lHeight = this.Height;
            if (lHeight > 300) {
                divLayout.style.height = (lHeight - toolbarDataObjectDiv.offsetHeight - 12) + "px";
                var lWidth = divLayout.offsetWidth;
                if (this.initialized == true) {
                    this.layout.setSizes();
                 }
            }
        }
    }

    ClientPrioritization.prototype.SetHeight = function (nHeight) {
        this.Height = nHeight;
        this.OnResize();
    }

    ClientPrioritization.prototype.GetClientPrioritizationData = function (result) {

        this.GridData = result;

        this.layout = new dhtmlXLayoutObject(this.clientID + "layoutDiv", "1C");
        this.layout.cells(this.mainArea).setText("Main Area");
        this.layout.cells(this.mainArea).hideHeader();
        this.layout.cells(this.mainArea).attachObject("gridDiv_1");


        var toolbarData = {
            parent: "toolbarDataObjectDiv",
            icon_path: this.imagePath,
            items: [
               { type: "button", id: "CloseBtn", text: "Close", tooltip: "Close" },
               { type: "button", id: "ApplyBtn", text: "Apply", tooltip: "Apply the changes" }
             ]
        };

        this.toolbar = new dhtmlXToolbarObject(toolbarData);
        this.toolbar.attachEvent("onClick", toolbarOnClickDelegate);
        this.initialized = true;
        this.OnResize();

        var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetGridLayout' layout_namespace='WorkEnginePPM' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetGridData' data_namespace='WorkEnginePPM' ></treegrid>";
        this.dataGrid = TreeGrid(sHTML1, "gridDiv_1", "g_1");
        PingSessionData();


    }



    ClientPrioritization.prototype.toolbarOnClick = function (id, data) {

        if (id == "CloseBtn") {
            if (SP.UI.DialogResult)
                SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
            else
                SP.UI.ModalDialog.commonModalDialogClose(0, '');


            return;
        }

        if (id == "ApplyBtn") {
            this.SaveDataBack();

        }
    }

    ClientPrioritization.prototype.SaveDataBack = function () {
        var Grid = Grids["g_1"];

        document.body.style.cursor = 'wait';

        var ix = Grid.EndEdit(true);
//        alert(ix);
        var arows = Grid.Rows;

        for (var r = 1; r <= Grid.RowCount; r++) {
            var xr = arows[r];

            for (var c = 1; c <= this.GridData.NumCols; c++) {
                var s = Grid.GetString(xr, "C" + c.toString());

                this.GridData.griddata[r - 1].rowdata[c - 1] = s;


            }

        }

        WorkEnginePPM.ClientPrioritization.SetClientPrioritizationData(this.GridData, SetClientPrioritizationDataDelegate);


    }


    ClientPrioritization.prototype.SetClientPrioritizationData = function (result) {
        document.body.style.cursor = 'default';

        if (result != "")
            alert(result);
        else
            alert("Prioritization Data applied successfully");
    }


    var PingSessionData = function () {

        try {


            window.setTimeout(HandlePingSessionData, 1000 * 60);
        }

        catch (e) {
        }
    }

    ClientPrioritization.prototype.HandlePingSession = function () {

        try {
            WorkEnginePPM.ClientPrioritization.DoPingSession();
            PingSessionData();
        }
        catch (e) {

        }

    }     
    // Initialised fields
    this.thisID = thisID;
    this.clientID = clientID; // Text ID of the parent control
    this.Path = Path;
    this.Webservice = Webservice;
    this.mainArea = "a";
    this.GridData = null;


    this.dataGrid = null;
    this.Dirty = false;

     this.tabbar = null;
    this.layout = null;
    this.initialized = false;
    this.Height = 0;
    this.imagePath = "/_layouts/ppm/images/";

    var loadDelegate = MakeDelegate(this, this.OnLoad);
    var unloadDelegate = MakeDelegate(this, this.OnUnload);
    var GetClientPrioritizationDataDelegate = MakeDelegate(this, this.GetClientPrioritizationData);
    var SetClientPrioritizationDataDelegate = MakeDelegate(this, this.SetClientPrioritizationData);
    var toolbarOnClickDelegate = MakeDelegate(this, this.toolbarOnClick);
    var HandlePingSessionData = MakeDelegate(this, this.HandlePingSession);


    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", loadDelegate, true);
        window.addEventListener("beforeunload", unloadDelegate, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", loadDelegate);
        window.attachEvent("onbeforeunload", unloadDelegate);
    }
}