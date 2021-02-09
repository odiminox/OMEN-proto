using System;
using System.Runtime.InteropServices;
using UnityEngine;
using OMEN.StatusHandling;

namespace OMEN.Core.Exceptions
{
    public class OMENException : Exception
    {
        protected OMENException(string statusCode, string message) : base(string.Format($"{statusCode}: {message}")) {}
    }
    public class ModLoaderPathException : OMENException
    {
        public ModLoaderPathException(string message) : base(CoreStatusCodes.ErrorRootPath, message) { }
    }
}
