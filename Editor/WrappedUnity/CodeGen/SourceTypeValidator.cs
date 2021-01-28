﻿using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public class SourceTypeValidator
    {
        public bool IsValidType(Type type, out string message)
        {
            message = null;
            if (type.IsDelegate())
            {
                message = "Type can not be a delegate";
            }

            if (type.IsAttribute())
            {
                message = "Type can not be an attribute";
            }

            if (type.IsClass)
            {
                return message.IsNullOrEmpty();
            }

            message = "Type should be a class";
            return false;
        }
    }
}