using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Events
{
    internal delegate void SocialEngineModuleDelegate<in T>(T e);

    internal class SocialEngineEvents
    {
        #region Properties (5) 

        public SocialEngineModuleDelegate<ProcessActivityEventArgs> OnActivityRegistration { get; set; }

        public SocialEngineModuleDelegate<ProcessActivityEventArgs> OnActivityRegistrationRequest { get; set; }

        public SocialEngineModuleDelegate<ProcessActivityEventArgs> OnPostActivityRegistration { get; set; }

        public SocialEngineModuleDelegate<ProcessActivityEventArgs> OnPreActivityRegistration { get; set; }

        public SocialEngineModuleDelegate<ProcessActivityEventArgs> OnValidateActivity { get; set; }

        #endregion Properties 
    }


    internal class ProcessActivityEventArgs : EventArgs
    {
        #region Fields (7) 

        private readonly ActivityKind _activityKind;
        private readonly ActivityManager _activityManager;
        private readonly SPWeb _contextWeb;
        private readonly Dictionary<string, object> _data;
        private readonly ObjectKind _objectKind;
        private readonly StreamManager _streamManager;
        private readonly ThreadManager _threadManager;

        #endregion Fields 

        #region Constructors (1) 

        public ProcessActivityEventArgs(ObjectKind objectKind, ActivityKind activityKind,
            Dictionary<string, object> data, SPWeb contextWeb,
            StreamManager streamManager, ThreadManager threadManager, ActivityManager activityManager)
        {
            _objectKind = objectKind;
            _activityKind = activityKind;
            _data = data;
            _contextWeb = contextWeb;
            _streamManager = streamManager;
            _threadManager = threadManager;
            _activityManager = activityManager;
        }

        #endregion Constructors 

        #region Properties (11) 

        public ActivityKind ActivityKind
        {
            get { return _activityKind; }
        }

        public ActivityManager ActivityManager
        {
            get { return _activityManager; }
        }

        public bool Cancel { get; set; }

        public string CancellationMessage { get; set; }

        public SPWeb ContextWeb
        {
            get { return _contextWeb; }
        }

        public Dictionary<string, object> Data
        {
            get { return _data; }
        }

        public bool EcecuteUntransactionedOperation { get; set; }

        public ObjectKind ObjectKind
        {
            get { return _objectKind; }
        }

        public StreamManager StreamManager
        {
            get { return _streamManager; }
        }

        public ThreadManager ThreadManager
        {
            get { return _threadManager; }
        }

        public Action UntransactionedOperation { get; set; }

        #endregion Properties 
    }
}