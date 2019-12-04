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

        #endregion

        #region admin

        #endregion

        #region blog

        #endregion

        #region category

        #endregion

        #region contact

        #endregion

        #region our-services

        #endregion

        #region site-infos

        // Get site info
        // title, keywords, description, logoUrl, degree
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
