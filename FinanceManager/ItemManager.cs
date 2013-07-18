using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace FinanceManager
{
    class ItemManager
    {
        private List<Item> items;
        private int id;

        public ItemManager()
        {
            items = new List<Item>();
            id = 0;
        }

        public List<Item> GetAllItems()
        {
            return items;
        }

        public void AddItem(Item i)
        {
            i.Id = ++id;
            items.Add(i);
        }

        public void RemoveItem(Item i)
        {
            items.Remove(i);
        }

        public void EditItem(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == item.Id)
                {
                    items[i] = item;
                }
            }
        }

        public bool LoadItems(string filename)
        {
            try
            {
                XDocument doc = XDocument.Load(filename);
                if (doc.Root == null)
                    return false;

                IEnumerable<Item> itemsFromFile = from itemElement in doc.Root.Elements()
                                                  select LoadItem(itemElement);
                items.AddRange(itemsFromFile);
                id = items.Max(t => t.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static Item LoadItem(XElement itemElement)
        {
            return new Item()
            {
                Id = (int)itemElement.Element("id"),
                Type = (TypeEnum) Enum.Parse(typeof(TypeEnum) , (String)itemElement.Element("type")),
                Date = (DateTime)itemElement.Element("date"), // Linq to XML umí načítat a ukládat DateTime
                Category = new Category { Name = (string)itemElement.Element("category") },
                Value = (decimal)itemElement.Element("value"), // nefunguje, protože hodnota není uložena pro XMLovksku s des. tečkou, ale s čárkou
                Description = (string)itemElement.Element("description")
            };
        }

        public void SaveItems(string filename)
        {
            XDocument doc = new XDocument(new XElement("items", AllElements()));
            doc.Save(filename);
        }

        private object[] AllElements()
        {
            object[] objects = new object[items.Count];
            int j = 0;
            foreach(Item i in items){
                objects[j++] = CreateElement(i);
            }

            return objects;
        }

        private object CreateElement(Item item)
        {
            return 
            new XElement("item",
                new XElement("id", item.Id),
                new XElement("type", item.Type),
                new XElement("date", item.Date),
                new XElement("value", item.Value),
                new XElement("category", item.Category.Name),
                new XElement("description", item.Description)
            );
        }

        /*public bool LoadItems(String file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            if (doc.FirstChild.Name != "items") return false;

            foreach (XmlNode item in doc.FirstChild.ChildNodes)
            {
                int itemId, year, month, day;
                String desc;
                TypeEnum type;
                DateTime date;
                Category categ;
                Decimal val;
                if (item.Name != "item")
                {
                    return false;
                }
                else
                {
                    XmlNodeList itemParams = item.ChildNodes;
                    if(itemParams.Count != 6) return false;

                    if (itemParams[0].Name != "id") return false;
                    else
                    {
                        if(!Int32.TryParse(itemParams[0].InnerText, out itemId)) return false;
                        if (itemId > id) id = itemId;
                    }

                    if (itemParams[1].Name != "type") return false;
                    else type =(TypeEnum) Enum.Parse(typeof(TypeEnum) , itemParams[1].InnerText);

                    if (itemParams[2].Name != "date") return false;
                    else
                    {
                        XmlNodeList dateParts = itemParams[2].ChildNodes;
                        if (dateParts.Count != 3) return false;

                        if (dateParts[0].Name != "year") return false;
                        else if(!Int32.TryParse(dateParts[0].InnerText, out year)) return false;

                        if (dateParts[1].Name != "month") return false;
                        else if(!Int32.TryParse(dateParts[1].InnerText, out month))return false;

                        if (dateParts[2].Name != "day") return false;
                        else if(!Int32.TryParse(dateParts[2].InnerText, out day)) return false;

                        date = new DateTime(year, month, day);
                    }

                    if (itemParams[3].Name != "value") return false;
                    else if(!Decimal.TryParse(itemParams[3].InnerText, out val)) return false;

                    if (itemParams[4].Name != "category") return false;
                    else
                    {
                        categ = new Category();
                        categ.Name = itemParams[4].InnerText;
                    }

                    if (itemParams[5].Name != "description") return false;
                    else desc = itemParams[5].InnerText;

                    Item i = new Item();
                    i.Id = itemId;
                    i.Category = categ;
                    i.Date = date;
                    i.Type = type;
                    i.Value = val;
                    i.Description = desc;

                    items.Add(i);
                }
            }

            return true;
        }*/

        /*public void SaveItems(String filename)
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("items");

            foreach (Item i in items)
            {
                root.AppendChild(CreateXmlElement(document, i));
            }

            document.AppendChild(root);
            document.Save(filename);
        }

        private XmlElement CreateXmlElement(XmlDocument doc, Item i)
        {
            XmlElement id = doc.CreateElement("id");
            id.AppendChild(doc.CreateTextNode(i.Id.ToString()));

            XmlElement type = doc.CreateElement("type");
            type.AppendChild(doc.CreateTextNode(i.Type.ToString()));

            XmlElement year = doc.CreateElement("year");
            year.AppendChild(doc.CreateTextNode(i.Date.Year.ToString()));
            XmlElement month = doc.CreateElement("month");
            month.AppendChild(doc.CreateTextNode(i.Date.Month.ToString()));
            XmlElement day = doc.CreateElement("day");
            day.AppendChild(doc.CreateTextNode(i.Date.Day.ToString()));
            XmlElement date = doc.CreateElement("date");
            date.AppendChild(year);
            date.AppendChild(month);
            date.AppendChild(day);

            XmlElement value = doc.CreateElement("value");
            value.AppendChild(doc.CreateTextNode(i.Value.ToString()));

            XmlElement category = doc.CreateElement("category");
            category.AppendChild(doc.CreateTextNode(i.Category.Name));

            XmlElement desc = doc.CreateElement("description");
            desc.AppendChild(doc.CreateTextNode(i.Description));

            XmlElement itemElement = doc.CreateElement("item");
            itemElement.AppendChild(id);
            itemElement.AppendChild(type);
            itemElement.AppendChild(date);
            itemElement.AppendChild(value);
            itemElement.AppendChild(category);
            itemElement.AppendChild(desc);

            return itemElement;
        }*/
    }
}
