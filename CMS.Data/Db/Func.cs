using Dapper;
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

        // Get blog list
        public static IEnumerable<Blogs> GetBlogs()
        {
            var connection = Repository.GetOpenConnection();
            {
                var blogs = connection.Find<Blogs>(statement => statement
                .Where($"{nameof(Blogs.isactive):C}=1"));

                return blogs;
            }
        }

        // Get blog id 
        public static Blogs GetBlogById(int blogId)
        {
            var connection = Repository.GetOpenConnection();
            {
                Blogs blogs = connection.Get(new Blogs { id = blogId });

                return blogs;
            }
        }

        // Insert blogs
        public static void SaveOrUpdateBlogs(Blogs blogs, int blogId)
        {
            if (blogId == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(blogs);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(blogs);
                }
            }
        }

        // Update isactive category
        public static void DeleteBlogById(int blogId)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "UPDATE Blogs SET isactive = 0 WHERE id = " + blogId;

                connection.Query(sql);
            }
        }

        #endregion

        #region category

        // Get category list
        public static IEnumerable<Categories> GetCategories()
        {
            var connection = Repository.GetOpenConnection();
            {
                var categories = connection.Find<Categories>(statement => statement
                .Where($"{nameof(Categories.isactive):C}=1"));

                return categories;
            }
        }

        // Get category by id 
        public static Categories GetCategoryById(int categoryId)
        {
            var connection = Repository.GetOpenConnection();
            {
                Categories categories = connection.Get(new Categories { id = categoryId });

                return categories;
            }
        }

        // Insert categories
        public static void SaveOrUpdateCategories(Categories categories, int categoryId)
        {
            if (categoryId == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(categories);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(categories);
                }
            }
        }

        // Update isactive category
        public static void DeleteCategoryById(int categoryId)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "UPDATE Categories SET isactive = 0 WHERE id = " + categoryId;

                connection.Query(sql);
            }
        }

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

        // Get our service list
        public static IEnumerable<OurServices> GetServices()
        {
            var connection = Repository.GetOpenConnection();
            {
                var services = connection.Find<OurServices>(statement => statement
                .Where($"{nameof(OurServices.isactive):C}=1"));

                return services;
            }
        }

        // Get our service by id 
        public static OurServices GetOurServiceById(int serviceId)
        {
            var connection = Repository.GetOpenConnection();
            {
                OurServices ourServices = connection.Get(new OurServices { id = serviceId });

                return ourServices;
            }
        }

        // Insert our services
        public static void SaveOrUpdateOurServices(OurServices ourServices, int serviceId)
        {
            if (serviceId == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(ourServices);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(ourServices);
                }
            }
        }

        // Update isactive our services 
        public static void DeleteOurServicesById(int serviceId)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "UPDATE OurServices SET isactive = 0 WHERE id = " + serviceId;

                connection.Query(sql);
            }
        }

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
