﻿using Dapper;
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

        public static IEnumerable<Admins> ValidateUser(string email, string password)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "SELECT * FROM Admins WHERE email = @Email and password = @Password;";

                IEnumerable<Admins> admins = connection.Query<Admins>(sql, new { Email = email, Password = password });

                return admins;
            }
        }

        // Get user list
        public static IEnumerable<Admins> GetAllUsers()
        {
            var connection = Repository.GetOpenConnection();
            {
                var admins = connection.Find<Admins>(statement => statement
                .Where($"{nameof(Admins.isactive):C}=1"));

                return admins;
            }
        }

        // Get user by id 
        public static Admins GetUserById(int userid)
        {
            var connection = Repository.GetOpenConnection();
            {
                Admins admins = connection.Get(new Admins { id = userid });

                return admins;
            }
        }

        // Insert admins
        public static void SaveOrUpdateCategories(Admins admins, int userid)
        {
            if (userid == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(admins);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(admins);
                }
            }
        }

        // Update isactive admin
        public static void DeleteUserById(int userid)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "UPDATE Admins SET isactive = 0 WHERE id = " + userid;

                connection.Query(sql);
            }
        }


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

        // Get blog id 
        public static IEnumerable<Blogs> GetBlogByCategoryId(int categoryid)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "select b.*, c.title as categoryName" + Environment.NewLine;
                sql += "from Blogs as b, Categories as c" + Environment.NewLine;
                sql += "where b.categoryid = c.id and b.isactive = 1 and b.categoryid = @categoryid" + Environment.NewLine;
                sql += "order by b.id desc" + Environment.NewLine;

                var blogs = connection.Query<Blogs>(sql, new { categoryid = new[] { categoryid } });

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

        public static IEnumerable<dynamic> GetSiteBlogs()
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "select b.*, c.title as categoryName" + Environment.NewLine;
                sql += "from Blogs as b, Categories as c" + Environment.NewLine;
                sql += "where b.categoryid = c.id and b.isactive = 1" + Environment.NewLine;
                sql += "order by b.id desc" + Environment.NewLine;

                var blogs = connection.Query(sql);

                return blogs;
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

        #region slides

        // Get slide list
        public static IEnumerable<Slides> GetSlides()
        {
            var connection = Repository.GetOpenConnection();
            {
                var slides = connection.Find<Slides>(statement => statement
                .Where($"{nameof(Slides.isactive):C}=1"));

                return slides;
            }
        }

        // Get slide by id 
        public static Slides GetSlideById(int slideId)
        {
            var connection = Repository.GetOpenConnection();
            {
                Slides slides = connection.Get(new Slides { id = slideId });

                return slides;
            }
        }

        // Insert slides
        public static void SaveOrUpdateSlides(Slides slides, int slideId)
        {
            if (slideId == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(slides);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(slides);
                }
            }
        }

        // Update isactive slide
        public static void DeleteSlideById(int slideId)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "UPDATE Slides SET isactive = 0 WHERE id = " + slideId;

                connection.Query(sql);
            }
        }

        #endregion

        #region comments

        // Get all comment list
        public static IEnumerable<Comments> GetAllComments()
        {
            var connection = Repository.GetOpenConnection();
            {
                string query = "SELECT * FROM Comments ORDER BY id DESC";

                var comments = connection.Query<Comments>(query);

                return comments;
            }
        }

        // Get active comment list
        public static IEnumerable<Comments> GetComments()
        {
            var connection = Repository.GetOpenConnection();
            {
                string query = "SELECT * FROM Comments WHERE isactive = 1 ORDER BY id DESC";

                var comments = connection.Query<Comments>(query);

                return comments;
            }
        }

        // Get active comment list by blog id
        public static IEnumerable<Comments> GetCommentByBlogID(int blogId)
        {
            var connection = Repository.GetOpenConnection();
            {
                string query = "SELECT * FROM Comments WHERE isactive = 1 and blogid = @BlogId ORDER BY id DESC";

                var comments = connection.Query<Comments>(query, new { BlogId = blogId });

                return comments;
            }
        }

        public static int GetPassiveCommentCount()
        {
            var connection = Repository.GetOpenConnection();
            {
                string query = "SELECT * FROM Comments WHERE isactive = 0 ORDER BY id DESC";

                var comments = connection.Query<Comments>(query);

                return comments.Count();
            }
        }

        // Get comment by id 
        public static Comments GetCommentById(int commentid)
        {
            var connection = Repository.GetOpenConnection();
            {
                Comments comments = connection.Get(new Comments { id = commentid });

                return comments;
            }
        }

        // Insert comments
        public static void SaveOrUpdateComments(Comments comments, int commentid)
        {
            if (commentid == 0) // save if user number is 0 
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Insert(comments);
                }
            }
            else // update if user number is not 0
            {
                var connection = Repository.GetOpenConnection();
                {
                    connection.Update(comments);
                }
            }
        }

        // Update isactive comment
        public static void DeleteCommentById(int commentid)
        {
            var connection = Repository.GetOpenConnection();
            {
                string sql = "UPDATE Comments SET isactive = 0 WHERE id = " + commentid;

                connection.Query(sql);
            }
        }

        #endregion
    }
}
