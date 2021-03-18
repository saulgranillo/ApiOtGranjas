using System;
using System.Collections.Generic;
using System.Text;

namespace ClbModOT
{
  public class ClsModResultado
    {
        public ClsModResultado()
        {
            this.MsgError = string.Empty;
        }

        public string MsgError { get; set; }
        public string MsgExito { get; set; }
        public int Id { get; set; }
        public List<ClsModResultado> lstResultado { get; set; }
        public bool Error { get { return !String.IsNullOrEmpty(MsgError);  } }
    }
}
