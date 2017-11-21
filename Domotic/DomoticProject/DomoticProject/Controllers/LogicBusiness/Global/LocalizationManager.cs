using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomoticProject.Controllers.LogicBusiness.Global
{
    public class LocalizationManager
    {
        // Singleton
        public static LocalizationManager instance;

        public LocalizationManager() { }

        public static LocalizationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalizationManager();
                }
                return instance;
            }
        }

        /// <summary>
        /// Instance to set the culture to the app, this instance must be called before of "InitializeComponent()" in the main Form.
        /// </summary>
        /// <param name="Culture">The Culture is the languague string.</param>
        /// <returns></returns>
        /// Author: Daniel Molina
        public void SetCulture(String Culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Culture);
            return;
        }

        /// <summary>
        /// Gets the database resource.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="tableFieldName">Name of the table field.</param>
        /// <param name="registerId">The register identifier.</param>
        /// <param name="defaultText">The default text.</param>
        /// <returns>Localized </returns>
        /// <Author> Daniel Molina. Sergio Rincon Botero </Author>
        /// <LastModification>  24/08/2016 - 11:16 a. m. </LastModification>
        /// <LastModificationBy> Sergio Rincon Botero </LastModificationBy>
        public String GetDatabaseResource(String tableName, String tableFieldName, String registerId, String defaultText)
        {
            //Locate the resource file depending of the resourceName
            ResourceManager rm = new ResourceManager("SmartEnergyDesktop.VegaEnergy.Resources.Table." + tableName + "." + tableFieldName, Assembly.GetExecutingAssembly());

            if (rm != null)
            {
                try
                {
                    String resourceLocalizated = rm.GetString(registerId);

                    if (resourceLocalizated != null || resourceLocalizated == "")
                    {
                        return resourceLocalizated;
                    }
                }
                catch (Exception)
                {
                }

            }

            return "[" + defaultText + "]";

        }

        /// <summary>
        /// Instance to localize the messages to show.
        /// </summary>
        /// <param name="messageName">The MessageName is the message to localize.</param>
        /// <returns>
        /// the localized message or the MessageName
        /// </returns>
        /// Author: Daniel Molina
        //public String GetMessageResource(String messageName)
        //{
        //    ResourceManager rm = SmartEnergyDesktop.VegaEnergy.Resources.Messages.ResourceManager;
        //    String resourceLocalizated = rm.GetString(messageName);
        //    if (resourceLocalizated != null || resourceLocalizated == "")
        //    {
        //        return resourceLocalizated;
        //    }
        //    return "[" + messageName + "]";
        //}

        /// <summary>
        /// Gets the message resource.
        /// </summary>
        /// <param name="messageName">Name of the message.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <Author> Sergio Rincon Botero. Daniel Molina </Author>
        /// <LastModification>  24/08/2016 - 11:44 a. m. </LastModification>
        /// <LastModificationBy> Sergio Rincon Botero </LastModificationBy>
        //public String GetMessageResource(String messageName, string[] parameters)
        //{
        //    string localizedResource = GetMessageResource(messageName);
        //    for (int i = 1; i <= parameters.Length; i++)
        //    {
        //        localizedResource = localizedResource.Replace("%" + i, parameters[i - 1]);
        //    }
        //    return localizedResource;
        //}

        /// <summary>
        /// Instance to localize or change the images to show.
        /// </summary>
        /// <param name="image">The Image is the image to localize or change.</param>
        /// <returns>the localized image or and Interrogation sign if the is not image in the resource file</returns>
        /// Author: Daniel Molina
        //public Image GetImageResource(String image)
        //{
        //    ResourceManager rm = SmartEnergyDesktop.VegaEnergy.Resources.Images.ResourceManager;
        //    Image myImage = (Image)rm.GetObject(image);
        //    if (myImage != null)
        //    {
        //        return myImage;
        //    }
        //    return (Image)rm.GetObject("Warning");
        //}
    }
}
