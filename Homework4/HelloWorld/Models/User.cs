using System.ComponentModel;

namespace HelloWorld.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string password = string.Empty;
        private string nameError;

        // Add ToString method
        public override string ToString()
        {
            return name;
        }

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return NameError;
            }
        }

        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnName]
        {
            get
            {
                NameError = "";
                switch (columnName)
                {
                    case "Name":
                        {
                            if (string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }
                            break;
                        }
                }
                return NameError;
            }
        }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

public interface IDataErrorInfo
{
    //
    // Summary:
    //     Gets the error message for the property with the given name.
    //
    // Parameters:
    //   columnName:
    //     The name of the property whose error message to get.
    //
    // Returns:
    //     The error message for the property. The default is an empty string ("").
    string this[string columnName] { get; }

    //
    // Summary:
    //     Gets an error message indicating what is wrong with this object.
    //
    // Returns:
    //     An error message indicating what is wrong with this object. The default is an
    //     empty string ("").
    string Error { get; }
}


// Summary:
//     Notifies clients that a property value has changed.
public interface INotifyPropertyChanged
{
    //
    // Summary:
    //     Occurs when a property value changes.
    event PropertyChangedEventHandler PropertyChanged;
}
