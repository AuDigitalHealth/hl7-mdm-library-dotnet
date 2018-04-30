/*
 * Copyright 2011 NEHTA
 *
 * Licensed under the NEHTA Open Source (Apache) License; you may not use this
 * file except in compliance with the License. A copy of the License is in the
 * 'license.txt' file, which should be provided with this work.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using MDM.Common.Attributes;

namespace MDM.Common.Extension
{
    /// <summary>
    /// General extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Generic method to deserialize an XML document.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="document">The XML document to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserialize<T>(this XmlDocument document)
        {
            if (document.DocumentElement == null)
                throw new ArgumentException(Properties.Resources.InvalidDocumentAttribute);

            XmlReader reader = document.CreateNavigator().ReadSubtree();
            // ReSharper disable PossibleNullReferenceException
            XmlRootAttribute rootAttr = new XmlRootAttribute(document.DocumentElement.LocalName);
            // ReSharper restore PossibleNullReferenceException
            rootAttr.Namespace = document.DocumentElement.NamespaceURI;
            XmlSerializer xs = new XmlSerializer(typeof(T), rootAttr);
            object rv = xs.Deserialize(reader);

            return (T)rv;
        }

        /// <summary>
        /// Generic method to deserialize an XML element.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserialize<T>(this XmlElement element)
        {
            XmlReader reader = element.CreateNavigator().ReadSubtree();
            XmlRootAttribute rootAttr = new XmlRootAttribute(element.LocalName);
            rootAttr.Namespace = element.NamespaceURI;
            XmlSerializer xs = new XmlSerializer(typeof(T), rootAttr);
            object rv = xs.Deserialize(reader);

            return (T)rv;
        }

        /// <summary>
        /// Serializes any object to XML.
        /// </summary>
        /// <param name="report">The object to serialize.</param>
        /// <returns>Xml of the serialized object.</returns>
        public static XmlDocument SerializeToXml(this Object report)
        {
            // Get XmlTypeAttribute
            XmlTypeAttribute xta = Attribute.GetCustomAttribute(report.GetType(), typeof(XmlTypeAttribute)) as XmlTypeAttribute;
            if (xta == null) throw new ArgumentException(Properties.Resources.InvalidDocumentAttribute);
            
            // Get XmlRootAttribute
            XmlRootAttribute xra = Attribute.GetCustomAttribute(report.GetType(), typeof(XmlRootAttribute)) as XmlRootAttribute;
            if (xra == null) xra = new XmlRootAttribute();
            xra.Namespace = xta.Namespace;

            XmlDocument output = new XmlDocument();
            output.PreserveWhitespace = true;

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            XmlWriter xmlw = XmlWriter.Create(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(report.GetType(), xra);
            xmlSerializer.Serialize(xmlw, report, xsn);
            xmlw.Close();

            output.LoadXml(sb.ToString());

            return output;
        }

        /// <summary>
        /// Serializes any object to XML.
        /// </summary>
        /// <param name="report">The object to serialize.</param>
        /// <param name="documentElementName">The xml document element name.</param>
        /// <returns>Xml of the serialized object.</returns>
        public static XmlDocument SerializeToXml(this Object report, string documentElementName)
        {
            if (string.IsNullOrEmpty(documentElementName))
                throw new ArgumentException(Properties.Resources.InvalidDocumentAttribute);

            XmlTypeAttribute xta = Attribute.GetCustomAttribute(report.GetType(), typeof(XmlTypeAttribute)) as XmlTypeAttribute;
            if (xta == null)
                throw new ArgumentException(Properties.Resources.InvalidDocumentAttribute);

            XmlDocument output = new XmlDocument();
            output.PreserveWhitespace = true;

            XmlRootAttribute xmlRoot = new XmlRootAttribute(documentElementName);
            xmlRoot.Namespace = xta.Namespace;

            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            XmlWriter xmlw = XmlWriter.Create(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(report.GetType(), xmlRoot);            
            xmlSerializer.Serialize(xmlw, report, xsn);
            xmlw.Close();

            output.LoadXml(sb.ToString());

            return output;
        }

        /// <summary>
        /// Extension Methods for retrieving a value from an attribute
        /// </summary>
        /// <typeparam name="T">The object / attribute type</typeparam>
        /// <typeparam name="TExpected">The expected return value type</typeparam>
        /// <param name="enumeration">The enum type that this method extends</param>
        /// <param name="expression">An expression specifying the property on the attribute you would like to retrun</param>
        /// <returns>The value as specified by the expression parameter</returns>
        public static TExpected GetAttributeValue<T, TExpected>
            (
                this Enum enumeration,
                Func<T, TExpected> expression
            )
            where T : Attribute
        {
            var attribute = enumeration.GetType().GetMember(enumeration.ToString())[0].GetCustomAttributes(typeof(T), false).Cast<T>().SingleOrDefault();

            return attribute == null ? default(TExpected) : expression(attribute);
        }

        /// <summary>
        /// Extension Methods for retrieving a value from an attribute
        /// </summary>
        /// <typeparam name="T">The object / attribute type</typeparam>
        /// <typeparam name="TExpected">The expected return value type</typeparam>
        /// <param name="enumeration">The enum type that this method extends</param>
        /// <param name="expression"></param>
        /// <returns>The value as specified by the expression parameter</returns>
        public static TExpected GetEnumByAttributeValue<T, TExpected>
            (
            this Type enumeration,
            Func<T, Boolean> expression
            )
            where T : Attribute
            
        {
            var enumValue = String.Empty;
            
            var fieldList = enumeration.GetFields().ToList();

            fieldList.ForEach
                (
                    field1 =>
                        {
                            var fieldInfo = enumeration.GetMember(field1.Name).FirstOrDefault();
                            
                            if (fieldInfo != null)
                            {
                                T attribute = fieldInfo.GetCustomAttributes(typeof(T), false).Cast<T>().FirstOrDefault();

                                if(
                                     expression(attribute)
                                   )
                                {
                                    enumValue = field1.Name;
                                }
                            }
                        }
                );
            return String.IsNullOrEmpty(enumValue) ? default(TExpected) : (TExpected)Enum.Parse(typeof(TExpected), enumValue);
        }

        /// <summary>
        /// Extension Methods for retrieving a value from an interface
        /// </summary>
        /// <typeparam name="T">The object / attribute type</typeparam>
        /// <typeparam name="TExpected">The expected return value type</typeparam>
        /// <param name="obj">The object this method extends</param>
        /// <param name="expression">An expression specifying the property on the attribute you would like to retrun</param>
        /// <param name="interfaceName">Name of the expected interface; E.g. the interface containing the attribute</param>
        /// <returns>The value as specified by the expression parameter</returns>
        public static TExpected GetAttributeValue<T, TExpected>
            (
                this object obj,
                Func<T, TExpected> expression,
                String interfaceName
            )
            where T : class
        {
            var implementedInterface = obj.GetType().GetInterface(interfaceName);

            T attribute = null;

            if (implementedInterface != null)
            {
                attribute = implementedInterface.GetCustomAttributes(typeof(T), false).Cast<T>().SingleOrDefault();
            }

            return attribute == null ? default(TExpected) : expression(attribute);
        }
    }
}
