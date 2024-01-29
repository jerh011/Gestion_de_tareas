﻿using Gestion_de_tareas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gestion_de_tareas.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VTareas : ContentPage
	{
        public VTareas(string _Estados)
        {
            InitializeComponent();
            BindingContext = new VMTareas(Navigation, _Estados);
          
        }
       
    }
}