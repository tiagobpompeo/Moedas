﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moedas.Droid.Helpers
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);//Acesso a Nossa Pasta do nosso aplicativo
            //Armazena o banco de dados em um arquivo local, que deve ser colocado em um caminho de pasta gravavel que seja especifico da plataforma
            return System.IO.Path.Combine(path, filename);// Pasta , o Nome absoluto do nosso banco de dados
            //System.IO , permite trabalhar diretamente com arquivos e pastas
        }
    }
}