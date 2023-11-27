using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;

[System.Xml.Serialization.XmlInclude(typeof(Helper))]
public class MaterialData
{
    public int MaterialBuilding { get; set; }
    public int Food { get; set; }
    public int Water { get; set; }
}

