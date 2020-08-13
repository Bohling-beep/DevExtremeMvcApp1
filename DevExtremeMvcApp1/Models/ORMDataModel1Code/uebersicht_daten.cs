using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace DevExtremeMvcApp1.Models.FuhrparkContext
{

    public partial class uebersicht_daten
    {
        public uebersicht_daten(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
