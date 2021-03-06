﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Northwind.WebForms
{
    public partial class Pordutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void criterioPesquisaRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            criterioPesquisaMultiview.ActiveViewIndex = Convert.ToInt32(criterioPesquisaRadioButtonList.SelectedValue);

            produtosGridView.DataSourceID = $"produtoPor{criterioPesquisaRadioButtonList.SelectedItem.Text}ObjectDataSource";

            if (criterioPesquisaMultiview.ActiveViewIndex == 1 && fornecedorDropDownList.Items.Count == 1)
            {
                fornecedorDropDownList.DataSourceID = "fornecedorObjectDataSource";
            }
        }
    }
}