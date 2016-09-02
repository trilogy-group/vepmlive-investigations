var ArrGantts = new Array();

if (!Array.prototype.indexOf) { Array.prototype.indexOf = function (needle) { for (var i = 0; i < this.length; i++) { if (this[i] === needle) { return i; } } return -1; }; }

window.Grids.OnClick = function (grid, row, col, x, y, evt) {
    //alert(grid.id);

    if (ArrGantts.indexOf(grid.id) > -1) {
        alert("GRID!");
    }
    return true;
}