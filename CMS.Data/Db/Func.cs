using Dapper.FastCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Db
{
    public class Func
    {
        #region about-us

        // Get about us
        // description, isactive, createddate
        public static AboutUs GetAboutUs()
        {
            var connection = Repository.GetOpenConnection();
            {
                var aboutUs = connection.Get(new AboutUs { id = 1 });

                return aboutUs;
            }
        }

        // Insert about us
        public static void SaveOrUpdateAboutUs(AboutUs aboutUs, int aboutusid)
        {
            if (aboutusid == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(aboutUs);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(aboutUs);
                }
            }
        }

        #endregion

        #region admin

        #endregion

        #region blog

        #endregion

        #region category

        #endregion

        #region contact

        // Get contact
        // address, phone, fax, email, whatsapp, facebook, twitter, instagram, isactive, createddate
        public static Contact GetContact()
        {
            var connection = Repository.GetOpenConnection();
            {
                var contact = connection.Get(new Contact { id = 1 });

                return contact;
            }
        }

        // Insert contact
        public static void SaveOrUpdateContact(Contact contact, int contactid)
        {
            if (contactid == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(contact);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(contact);
                }
            }
        }

        #endregion

        #region our-services

        #endregion

        #region site-infos

        // Get site info
        // title, keywords, description, logoUrl, degree, isactive, createddate
        public static SiteInfos GetSiteInfos()
        {
            var connection = Repository.GetOpenConnection();
            {
                var siteInfos = connection.Get(new SiteInfos { id = 1 });

                return siteInfos;
            }
        }

        // Insert site info
        public static void SaveOrUpdateSiteInfos(SiteInfos siteInfos, int siteinfoid)
        {
            if (siteinfoid == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(siteInfos);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(siteInfos);
                }
            }
        }


        #endregion
    }
}
