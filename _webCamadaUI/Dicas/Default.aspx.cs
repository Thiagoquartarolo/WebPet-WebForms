﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sonserina.EscritorioDeProjetos.WebPet.Dicas
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (User.Identity.IsAuthenticated != true)
                Response.Redirect("~/Login/Default.aspx");
		}
	}
}