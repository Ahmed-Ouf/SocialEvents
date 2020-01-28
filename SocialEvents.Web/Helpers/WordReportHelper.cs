using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Xml;

namespace SocialEvents.Web.Helpers
{
    public class WordReportHelper
    {
        public static void DownloadExcel(DataTable dt)
        {
            HttpContext.Current.Session["dtResult"] = dt;
            HttpContext.Current.Response.Redirect("~/Agent/ExGrid.aspx");
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static string InsertRepeatedRow(string xmlData, string WordInRowToReplace, DataTable dtData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            XmlNode trStart = null;
            XmlNode Table = null;
            XmlNode trEnd = null;
            XmlNodeList nodeList = doc.GetElementsByTagName("w:t");
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].InnerText.Contains(WordInRowToReplace))
                {
                    trStart = GetParent(nodeList[i], "w:tr");
                    Table = GetParent(nodeList[i], "w:tbl");
                }
            }
            Table.RemoveChild(trStart);

            //  XmlDataDocument docstart = new XmlDataDocument();
            //docstart.LoadXml(fileStart);
            XmlNode currentNode = trStart;
            string replaceText = trStart.OuterXml;
            System.Text.StringBuilder rows = new System.Text.StringBuilder();
            string tempRow = "";
            for (int rowIndex = 0; rowIndex < dtData.Rows.Count; rowIndex++)
            {
                XmlNode node = trStart.CloneNode(true);
                for (int i = 0; i < dtData.Columns.Count; i++)
                {
                    tempRow = node.InnerXml;
                    tempRow = tempRow.Replace("SN", (rowIndex + 1).ToString());
                    tempRow = tempRow.Replace("" + dtData.Columns[i].ColumnName, dtData.Rows[rowIndex][i].ToString().Replace(".0000000000", "").Replace("00000000", "").Replace(".00000000", "").Replace(".0000", "")).Replace("&", "").Replace(".00", "");
                    node.InnerXml = tempRow;
                }

                Table.AppendChild(node);
            }

            return doc.OuterXml;
        }

        public static string InsertRepeatedListItem(string xmlData, string WordInRowToReplace, DataTable dtData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            XmlNode trStart = null;
            XmlNode Table = null;
            XmlNode trEnd = null;
            XmlNodeList nodeList = doc.GetElementsByTagName("w:t");
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].InnerText.Contains(WordInRowToReplace))
                {
                    trStart = GetParent(nodeList[i], "w:p");
                    Table = GetParent(nodeList[i], "wx:sect");
                }
            }
            Table.RemoveChild(trStart);

            XmlNode currentNode = trStart;
            string replaceText = trStart.OuterXml;
            System.Text.StringBuilder rows = new System.Text.StringBuilder();
            string tempRow = "";
            for (int rowIndex = 0; rowIndex < dtData.Rows.Count; rowIndex++)
            {
                XmlNode node = trStart.CloneNode(true);
                for (int i = 0; i < dtData.Columns.Count; i++)
                {
                    tempRow = node.InnerXml;
                    //  tempRow = tempRow.Replace("SN", (rowIndex + 1).ToString());
                    tempRow = tempRow.Replace("" + dtData.Columns[i].ColumnName, dtData.Rows[rowIndex][i].ToString().Replace(".0000000000", "").Replace("00000000", "").Replace(".00000000", "").Replace(".0000", "")).Replace("&", "").Replace(".00", "");
                    node.InnerXml = tempRow;
                }

                Table.AppendChild(node);
            }

            return doc.OuterXml;
        }

        public static string InsertRepeatedListItemOfTBContent(string xmlData, string WordInRowToReplace, DataTable dtData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            XmlNode trStart = null;
            XmlNode Table = null;
            XmlNode trEnd = null;
            XmlNodeList nodeList = doc.GetElementsByTagName("w:t");
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].InnerText.Contains(WordInRowToReplace))
                {
                    trStart = GetParent(nodeList[i], "w:p");
                    Table = GetParent(nodeList[i], "w:txbxContent");
                }
            }
            Table.RemoveChild(trStart);

            XmlNode currentNode = trStart;
            string replaceText = trStart.OuterXml;
            System.Text.StringBuilder rows = new System.Text.StringBuilder();
            string tempRow = "";
            for (int rowIndex = 0; rowIndex < dtData.Rows.Count; rowIndex++)
            {
                XmlNode node = trStart.CloneNode(true);
                for (int i = 0; i < dtData.Columns.Count; i++)
                {
                    tempRow = node.InnerXml;
                    //  tempRow = tempRow.Replace("SN", (rowIndex + 1).ToString());
                    tempRow = tempRow.Replace("" + dtData.Columns[i].ColumnName, dtData.Rows[rowIndex][i].ToString().Replace(".0000000000", "").Replace("00000000", "").Replace(".00000000", "").Replace(".0000", "")).Replace("&", "").Replace(".00", "");
                    node.InnerXml = tempRow;
                }

                Table.AppendChild(node);
            }

            return doc.OuterXml;
        }

        public static string InsertImage(string xmlData, string WordInRowToReplace, string ImageBase64, DataTable dtData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            XmlNode ShapeData = null;
            XmlNode PicData = null;
            XmlNodeList xmlNodeImg = doc.GetElementsByTagName("v:imagedata");

            for (int f = 0; f < xmlNodeImg.Count; f++)
            {
                for (int i = 0; i < xmlNodeImg[f].Attributes.Count; i++)
                {
                    if (xmlNodeImg[f].Attributes[i].Name == "o:title" && xmlNodeImg[f].Attributes[i].Value.Contains(WordInRowToReplace))
                    {
                        ShapeData = GetParent(xmlNodeImg[f], "v:shape");
                        PicData = GetParent(ShapeData, "w:pict");
                        for (int t = 0; t < PicData.ChildNodes.Count; t++)
                        {
                            if (PicData.ChildNodes[t].Name == "w:binData")
                            {
                                //PicData.ChildNodes[t].InnerText = @"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";
                                PicData.ChildNodes[t].InnerText = ImageBase64;
                            }
                        }
                    }
                    break;
                }
            }
            return doc.OuterXml;
        }

        public static XmlNode GetParent(XmlNode child, string tagName)
        {
            if (child.ParentNode != null)
            {
                if (child.ParentNode.Name == tagName)
                    return child.ParentNode;
                else
                    return GetParent(child.ParentNode, tagName);
            }
            else
                return null;
        }
    }
}