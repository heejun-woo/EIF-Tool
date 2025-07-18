using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIF_Tolls
{
    public static class StyleClass
    {
        private const MetroColorStyle FormStyle = MetroColorStyle.Blue;
        private const MetroThemeStyle FormThems = MetroThemeStyle.Dark;
        public static MetroStyleManager SetStyle(this IContainer container, MetroForm ownerForm)
        {
            if (container == null)
            {
                container = new System.ComponentModel.Container();
            }
            var manager = new MetroFramework.Components.MetroStyleManager(container);
            manager.Owner = ownerForm;
            container.SetDefaultStyle(ownerForm, FormStyle);
            container.SetDefaultTheme(ownerForm, FormThems);


            return manager;

        }

        public static void SetStyle(this IContainer container, MetroForm ownerForm, MetroStyleManager manager)
        {
            container.SetDefaultStyle(ownerForm, FormStyle, manager);
            container.SetDefaultTheme(ownerForm, FormThems, manager);

        }
        public static void SetDefaultStyle(this IContainer contr, MetroForm owner, MetroColorStyle style)
        {
            MetroStyleManager manager = FindManager(contr, owner);
            manager.Style = style;
            owner.Style = style;           

        }

        public static void SetDefaultStyle(this IContainer contr, MetroForm owner, MetroColorStyle style, MetroStyleManager manager)
        {
            manager.Style = style;
            owner.Style = style;

        }
        public static void SetDefaultTheme(this IContainer contr, MetroForm owner, MetroThemeStyle thme)
        {
            MetroStyleManager manager = FindManager(contr, owner);
            manager.Theme = thme;
        }

        public static void SetDefaultTheme(this IContainer contr, MetroForm owner, MetroThemeStyle thme, MetroStyleManager manager)
        {
            manager.Theme = thme;
        }
        private static MetroStyleManager FindManager(IContainer contr, MetroForm owner)
        {
            MetroStyleManager manager = null;
            foreach (IComponent item in contr.Components)
            {
                if (((MetroStyleManager)item).Owner == owner)
                {
                    manager = (MetroStyleManager)item;
                }
            }
            return manager;
        }
    }
}
