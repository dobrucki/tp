﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class A
    {
        public string Name { get; set; }
        public C GetC { get; set; }

<<<<<<< HEAD
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            else
            {
                A other = obj as A;
                return string.Compare(this.Name, other.Name) < 0 ? false : true;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
=======

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetType().FullName.ToString() + ",");
            sb.Append(idGenerator.GetId(GetC, out bool firstTime) + ",");
            sb.Append(Name + ",");
            sb.Append(idGenerator.GetId(this, out firstTime));
            return sb.ToString();
        }

        public void Deserialize(List<string> splitString)
        {
            Name = splitString[2];
        }


>>>>>>> d23eda9d6c6b8cd8b3f86d8682320a7f3c2253ac
    }

}
