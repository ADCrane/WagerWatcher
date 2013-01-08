﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("meeting")]
    public class XMLMeetingFromResults
    {
        [XmlElement("races")]
        public List<XMLRaceFromResults> Races { get; set; }

        [XmlAttribute("number")]
        public string JetBetCode { get; set; }
    }
}