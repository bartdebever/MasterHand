using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Reflection;
using MeleeLib;
using MeleeLib.MeleeTypes;

namespace MasterHand
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Title += " " + Assembly.GetExecutingAssembly().GetName().Version;
        }

		private void CreateHtmlOutput(DatFile dat)
        {
            var h1Template = "<h1>{0}</h1>";
            var h2Template = "<h2>{0}</h2>";
            var stringBuilder = new StringBuilder();
            //PrettyPrint XD
            stringBuilder.AppendFormat(h1Template,dat.Filename);
            PrettyPrint(dat.Header, stringBuilder);
            stringBuilder.AppendFormat(h2Template,"Section Type 1's");
            foreach (var name in dat.Section1Entries.Keys)
            {
                stringBuilder.AppendLine(name);
                PrettyPrint(dat.Section1Entries[name], stringBuilder);
            }
            stringBuilder.AppendFormat(h2Template,"Section Type 2's");
            foreach (var name in dat.Section2Entries.Keys)
            {
                stringBuilder.AppendLine(name);
                PrettyPrint(dat.Section2Entries[name], stringBuilder);
            }
            stringBuilder.AppendFormat(h2Template,"FTHeader");
            PrettyPrint(dat.FTHeader, stringBuilder);
            stringBuilder.AppendFormat(h2Template, "Attributes");
            stringBuilder.AppendLine("<table>");
            foreach (var attribute in dat.Attributes)
            {
                stringBuilder.AppendFormat("<tr><td>0x{0:X3}</td><td>{1}</td></tr>\n", attribute.Offset, attribute.Value);
            }
            stringBuilder.AppendLine("</table>");
            stringBuilder.AppendFormat(h2Template, "Subaction Headers");
            foreach(var s in dat.Subactions)
            {
                PrettyPrint(s.Header, stringBuilder);
            }
            Overview.NavigateToString(stringBuilder.ToString());
        }


		private static void PrettyPrint(object element, StringBuilder stringBuilder)
		{
			stringBuilder.AppendLine("<table>");
			foreach (var propertyInfo in element.GetType().GetProperties())
			{

				if (propertyInfo.Name.Contains("Offset") && !propertyInfo.Name.Contains("Count"))
				{
					stringBuilder.AppendFormat("<tr><td>{0:6}</td><td>@0x{1:X8}</td></tr>\n", propertyInfo.Name,
						propertyInfo.GetValue(element, null));
				}
				else if (propertyInfo.Name.Contains("Flags"))
				{
					stringBuilder.AppendFormat("<tr><td>{0:6}</td><td>{1:032}</td></tr>\n", propertyInfo.Name,
						Convert.ToString((uint)propertyInfo.GetValue(element, null), 2));
				}
				else
				{
					stringBuilder.AppendFormat("<tr><td>{0:6}</td><td>{1}</td></tr>\n", propertyInfo.Name,
						propertyInfo.GetValue(element, null));
				}

			}
			stringBuilder.AppendLine("</table>");
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            if (!dialog.ShowDialog().Value)
                return;
            var datfile = new DatFile(dialog.FileName);
            DataContext = datfile;
            var list = new List<SectionHeader>();

            foreach (var sh in datfile.Section1Entries.Values)
                list.Add(sh);
            foreach (var sh in datfile.Section2Entries.Values)
                list.Add(sh);
            DSListBox.ItemsSource = list;
            CreateHtmlOutput(datfile);

        }
    }
}
