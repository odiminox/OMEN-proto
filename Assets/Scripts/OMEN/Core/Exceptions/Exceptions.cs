using System;
using System.Runtime.InteropServices;
using UnityEngine;
using OMEN.StatusHandling;

namespace OMEN.Core.Exceptions
{
    public class OMENException : Exception
    {
        protected OMENException(string statusCode, string message) : base(string.Format($"{statusCode}: {message}")) {}
        protected OMENException(string statusCode) : base(statusCode) { }
    }
    public class ModLoaderPathException : OMENException
    {
        public ModLoaderPathException(string message) : base(CoreStatusCodes.ErrorRootPath, message) { }
    }
    
    public class ModLoaderInitialisedException : OMENException
    {
        public ModLoaderInitialisedException () : base(CoreStatusCodes.ErrorModLoaderInitialised) { }
    }
    
    public class MapLoaderNameException : OMENException
    {
        public MapLoaderNameException (string message) : base(CoreStatusCodes.ErrorMapName, message) { }
    }
    
    public class InvalidEntitySpawnerException : OMENException
    {
        public InvalidEntitySpawnerException () : base(CoreStatusCodes.ErrorEntitySpawner) { }
    }
    
    public class InvalidModLoaderException : OMENException
    {
        public InvalidModLoaderException () : base(CoreStatusCodes.ErrorModLoader) { }
    }
}
