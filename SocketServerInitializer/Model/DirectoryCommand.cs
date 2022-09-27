﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    public enum CRUDType
    {
        Create,
        Delete
    }
    public class DirectoryCommand : NotCmdCommand
    {
        public CRUDType commandType { get; set; }
    }
}