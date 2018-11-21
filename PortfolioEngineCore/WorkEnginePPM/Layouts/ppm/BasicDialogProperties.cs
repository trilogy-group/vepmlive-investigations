namespace WorkEnginePPM.Layouts.ppm2
{
    public class BasicDialogProperties
    {
        private string _dialogTitle;

        public string DialogTitle
        {
            get { return _dialogTitle; }
            set { _dialogTitle = value; }
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _desc;

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}