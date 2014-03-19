using System;
using GalaSoft.MvvmLight;
using CryBlendSpace.Model;

namespace CryBlendSpace.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private readonly IDataService _dataService;
        private String _fileName = "Something.bspace";
        private Boolean _isEditingFileName;
        private ParaGroup _header;

        #endregion

        #region Properties

        public String FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                RaisePropertyChanged("FileName");
            }
        }

        public Boolean IsEditingFileName
        {
            get { return _isEditingFileName; }
            set
            {
                _isEditingFileName = value;
                RaisePropertyChanged("IsEditingFileName");
            }
        }

        public ParaGroup Header
        {
            get { return _header; }
            set
            {
                _header = value;
                RaisePropertyChanged("Header");
            }
        } 

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        #region Commands

        #region NewCommand

        #endregion

        #region OpenCommand

        #endregion

        #region SaveCommand

        #endregion

        #region SaveAsCommand

        #endregion

        #endregion

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}