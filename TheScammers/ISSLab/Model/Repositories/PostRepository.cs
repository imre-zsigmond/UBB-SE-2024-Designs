using ISSLab.Services;
using Lab3_1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
namespace ISSLab.Model.Repositories
{
    class PostRepository
    {
        private readonly DataSet dataSet;
        private readonly string connectionString;
        List<Post> posts;
        Guid groupID;

        public PostRepository()
        {
            dataSet = new DataSet();
            connectionString = "Data Source=DESKTOP-1VJ4V0K;Initial Catalog=ISSLab;Integrated Security=True";
            posts = new List<Post>();
            groupID = Guid.NewGuid();
        }
        public PostRepository(DataSet dataSet, Guid _groupID)
        {
            this.dataSet = dataSet;
            this.connectionString = "data source=Soundboard\\SQLEXPRESS;initial catalog=master;trusted_connection=true";
            this.posts = new List<Post>();
            this.groupID = _groupID;

            //using (SqlConnection connection = new SqlConnection(this.connectionString))
            //{
            //    connection.Open();
            //    string selectAllUsersQuery = "SELECT * FROM Posts";
            //    string selectAllSharedPosts = "SELECT * FROM UsersSharedPosts";
            //    string selectAllLikedPosts = "SELECT * FROM UsersLikedPosts";
            //    string selectAllComments = "SELECT * FROM Comments";
            //    string selectAllFavoritedPosts = "SELECT * FROM Favorites";
            //    string selectAllReports = "SELECT * FROM Reports";
            //    string selectAllInterestStatuses = "SELECT * FROM InterestStatuses";

            //    SqlDataAdapter usersDataAdapter = new SqlDataAdapter(selectAllUsersQuery, connection);
            //    SqlDataAdapter sharedPostsDataAdapter = new SqlDataAdapter(selectAllSharedPosts, connection);
            //    SqlDataAdapter likedPostsDataAdapter = new SqlDataAdapter(selectAllLikedPosts, connection);
            //    SqlDataAdapter commentsDataAdapter = new SqlDataAdapter(selectAllComments, connection);
            //    SqlDataAdapter favoritedPostsDataAdapter = new SqlDataAdapter (selectAllFavoritedPosts, connection);
            //    SqlDataAdapter reportsDataAdapter = new SqlDataAdapter(selectAllReports, connection);
            //    SqlDataAdapter interestStatusesDataAdapter = new SqlDataAdapter(selectAllInterestStatuses, connection);

            //    usersDataAdapter.Fill(dataSet, "Posts");
            //    sharedPostsDataAdapter.Fill(dataSet, "UsersSharedPosts");
            //    likedPostsDataAdapter.Fill(dataSet, "UsersLikedPosts");
            //    commentsDataAdapter.Fill(dataSet, "Comments");
            //    favoritedPostsDataAdapter.Fill(dataSet, "Favorites");
            //    reportsDataAdapter.Fill(dataSet, "Reports");
            //    interestStatusesDataAdapter.Fill(dataSet, "InterestStatuses");

            //    DataTable postsTable = dataSet.Tables["Posts"];
            //    DataTable sharedPostsTable = dataSet.Tables["UsersSharedPosts"];
            //    DataTable likedPostsTable = dataSet.Tables["UsersLikedPosts"];
            //    DataTable commentsTable = dataSet.Tables["Comments"];
            //    DataTable favoritedPostsTable = dataSet.Tables["Favorites"];
            //    DataTable reportsTable = dataSet.Tables["Reports"];
            //    DataTable interestStatusesTable = dataSet.Tables["InterestStatuses"];
            //    //private Guid id;
            //    //private List<Guid> usersThatShared;
            //    //private List<Guid> usersThatLiked;
            //    //private List<Comment> comments;
            //    //private string media;
            //    //private DateTime creationDate;
            //    //private Guid authorId;
            //    //private Guid groupId;
            //    //private bool promoted;
            //    //private List<Guid> usersThatFavorited;
            //    //private List<Report> reports;
            //    //private string location;
            //    //private string description;
            //    //private string title;
            //    //private List<InterestStatus> interestStatuses;
            //    //private string contacts;
            //    //private string type;

            //    foreach(DataRow row1 in postsTable.Rows)
            //    {
            //        if ((Guid)row1["group_id"] == groupID) {
            //            Guid id = (Guid)row1["Id"];
            //            List<Guid> usersThatShared = new List<Guid>();
            //            foreach (DataRow row2 in sharedPostsTable.Rows)
            //            {
            //                if ((Guid)row2["post_id"] == id)
            //                {
            //                    usersThatShared.Add((Guid)row2["user_id"]);
            //                }
            //            }
            //            List<Guid> usersThatLiked = new List<Guid>();
            //            foreach (DataRow row2 in likedPostsTable.Rows)
            //            {
            //                if ((Guid)row2["post_id"] == id)
            //                {
            //                    usersThatLiked.Add((Guid)row2["user_id"]);
            //                }
            //            }
            //            List<Comment> comments = new List<Comment>();
            //            // Here we should add all the comments
            //            //foreach (DataRow row2 in commentsTable.Rows)
            //            //{
            //            //    if ((Guid)row2["post_id"] == id)
            //            //    {
            //            //        Guid
            //            //    }
            //            //}
            //            string media = (string)row1["media"];
            //            DateTime creationDate = (DateTime)row1["creation_date"];
            //            Guid authorId = (Guid)row1["author_id"];
            //            Guid groupId = (Guid)row1["group_id"];
            //            bool promoted = (bool)row1["promoted"];
            //            List<Guid> usersThatFavorited = new List<Guid>();
            //            foreach(DataRow row2 in favoritedPostsTable.Rows)
            //            {
            //                if ((Guid)row2["post_id"] == id)
            //                {
            //                    usersThatFavorited.Add((Guid)row2["user_id"]);
            //                }
            //            }
            //            List<Report> reports = new List<Report>();
            //            //private Guid id;
            //            //private Guid userId;
            //            //private Guid postId;
            //            //private string reason;
            //            //private DateTime date;
            //            foreach(DataRow row2 in reportsTable.Rows)
            //            {
            //                if ((Guid)row2["post_id"] == id)
            //                {
            //                    Guid reportId = (Guid)row2["id"];
            //                    Guid userId = (Guid)row2["user_id"];
            //                    Guid postId = (Guid)row2["post_id"];
            //                    string reason = (string)row2["reason"];
            //                    DateTime date = (DateTime)row2["date"];
            //                    Report newReport = new Report(reportId, userId, postId, reason, date);
            //                    reports.Add(newReport);
            //                }
            //            }
            //            string location = (string)row1["location"];
            //            string description = (string)row1["description"];
            //            string title = (string)row1["title"];
            //            List<InterestStatus> interstStatuses = new List<InterestStatus>();
            //            foreach(DataRow row2 in interestStatusesTable.Rows)
            //            {
            //                if((Guid)row2["post_id"] == id)
            //                {
            //                    Guid userId = (Guid)row2["user_id"];
            //                    Guid postId = (Guid)row2["post_id"];
            //                    bool interested = (bool)row2["interested"];
            //                    InterestStatus interestStatus = new InterestStatus(userId, postId, interested);
            //                    interstStatuses.Add(interestStatus);
            //                }
            //            }
            //            string contacts = (string)row1["contacts"];
            //            string type = (string)row1["type"];
            //            Post newPost = new Post(id, usersThatShared, usersThatLiked, comments, media, creationDate, authorId, groupId, promoted, usersThatFavorited, location, description, title, interstStatuses, contacts, reports, type, false, 0);
            //            posts.Add(newPost);
            //        }
            //    }
        }
        

        public void addPost(Post newPost)
        {
            //DataRow newRow = dataSet.Tables["Posts"].NewRow();
            //newRow["id"] = newPost.Id;
            //newRow["media"] = newPost.Media;
            //newRow["creationDate"] = newPost.CreationDate;
            //newRow["author_id"] = newPost.AuthorId;
            //newRow["group_id"] = newPost.GroupId;
            //newRow["promoted"] = newPost.Promoted;
            //newRow["location"] = newPost.Location;
            //newRow["description"] = newPost.Description;
            //newRow["title"] = newPost.Title;
            //newRow["type"] = newPost.Type;
            //newRow["contacts"] = newPost.Contacts;
            posts.Add(newPost);
        }

        public void removePost(Guid id) {
            DataRow postRow = dataSet.Tables["Posts"].Rows.Find(id);
            if (postRow != null)
            {
                postRow.Delete();
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts.RemoveAt(i);
                    break;
                }
            }

            DataTable usersThatSharedTable = dataSet.Tables["UsersSharedPosts"];

            List<DataRow> rowsToDelete = new List<DataRow>();

            // Iterate through each row in the DataTable
            foreach (DataRow row in usersThatSharedTable.Rows)
            {
                // Check if the "Age" column value matches the specified age
                if (row["post_id"] != DBNull.Value && (Guid)row["post_id"] == id)
                {
                    // If the condition is met, add the row to the list of rows to delete
                    rowsToDelete.Add(row);
                }
            }

            // Remove the rows from the DataTable
            foreach (DataRow rowToDelete in rowsToDelete)
            {
                usersThatSharedTable.Rows.Remove(rowToDelete);
            }


            DataTable usersThatLikedTable = dataSet.Tables["UsersLikedPosts"];
            List<DataRow> rowsToDelete2 = new List<DataRow>();
            foreach (DataRow row in usersThatLikedTable.Rows)
            {
                if (row["post_id"] != DBNull.Value && (Guid)row["post_id"] == id)
                {
                    rowsToDelete2.Add(row);
                }
            }

            foreach(DataRow rowToDelete in rowsToDelete2)
            {
                usersThatLikedTable.Rows.Remove(rowToDelete);
            }


            DataTable commentsTable = dataSet.Tables["Comments"];
            List<DataRow> rowsToDelete3 = new List<DataRow>();
            foreach (DataRow row in commentsTable.Rows)
            {
                if (row["post_id"] != DBNull.Value && (Guid)row["post_id"] == id)
                {
                    rowsToDelete3.Add(row);
                }
            }

            foreach (DataRow rowToDelete in rowsToDelete3)
            {
                commentsTable.Rows.Remove(rowToDelete);
            }

            DataTable usersThatFavoritedTable = dataSet.Tables["Favorites"];
            List<DataRow> rowsToDelete4 = new List<DataRow>();
            foreach (DataRow row in usersThatFavoritedTable.Rows)
            {
                if (row["post_id"] != DBNull.Value && (Guid)row["post_id"] == id)
                {
                    rowsToDelete4.Add(row);
                }
            }

            foreach (DataRow rowToDelete in rowsToDelete4)
            {
                usersThatFavoritedTable.Rows.Remove(rowToDelete);
            }

            DataTable reportsTable = dataSet.Tables["Reports"];
            List<DataRow> rowsToDelete5 = new List<DataRow>();
            foreach (DataRow row in reportsTable.Rows)
            {
                if (row["post_id"] != DBNull.Value && (Guid)row["post_id"] == id)
                {
                    rowsToDelete5.Add(row);
                }
            }

            foreach (DataRow rowToDelete in rowsToDelete5)
            {
                reportsTable.Rows.Remove(rowToDelete);
            }

            DataTable interestStatusesTable = dataSet.Tables["InterestStatuses"];
            List<DataRow> rowsToDelete6 = new List<DataRow>();
            foreach (DataRow row in interestStatusesTable.Rows)
            {
                if (row["post_id"] != DBNull.Value && (Guid)row["post_id"] == id)
                {
                    rowsToDelete6.Add(row);
                }
            }

            foreach (DataRow rowToDelete in rowsToDelete6)
            {
                interestStatusesTable.Rows.Remove(rowToDelete);
            }


        }

        public void updatePostShare(Guid id, Guid userId)
        {
            DataRow row = dataSet.Tables["UsersSharedPosts"].NewRow();
            row["post_id"] = id.ToString();
            row["user_id"] = userId.ToString();

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].toggleShare(userId);
                    break;
                }
            }
        }

        public void updatePostLike(Guid id, Guid userId)
        {
            DataRow row = dataSet.Tables["UsersLikedPosts"].NewRow();
            row["post_id"] = id.ToString();
            row["user_id"] = userId.ToString();

            for(int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].toggleLike(userId);
                    break;
                }
            }
        }

        public void updatePostComment(Guid id, Comment comment)
        {
            DataRow row = dataSet.Tables["Comments"].NewRow();
            row["id"] = comment.Id.ToString();
            row["content"] = comment.Content;
            row["user_id"] = comment.UserId;

            for(int i =  0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].addComment(comment);
                    break;
                }
            }
        }

        public void updatePostMedia(Guid id, string newMedia)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["media"] = newMedia;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].Media = newMedia;
                    break;
                }
            }
        }

        public void updateCreationDate(Guid id, DateTime newCreationDate)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["creation_date"] = newCreationDate;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].CreationDate = newCreationDate;
                    break;
                }
            }
        }

        public void updatePromoted(Guid id, bool newPromoted)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["promoted"] = newPromoted;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].Promoted = newPromoted;
                    break;
                }
            }
        }

        public void updatePostFavorite(Guid id, Guid userId, Guid groupId)
        {
            DataRow row = dataSet.Tables["Favorites"].NewRow();
            row["post_id"] = id.ToString();
            row["user_id"] = userId.ToString();
            row["group_id"] = groupId.ToString();

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].toggleFavorite(userId);
                    break;
                }
            }
        }

        public void updatePostReport(Guid id, Report report)
        {
            DataRow row = dataSet.Tables["Reports"].NewRow();
            row["id"] = report.Id.ToString();
            row["user_id"] = report.UserId.ToString();
            row["post_id"] = report.PostId.ToString();
            row["reason"] = report.Reason;
            row["date"] = report.Date;

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].addReport(report);
                    break;
                }
            }
        }

        public void updateLocation(Guid id, string newLocation)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["location"] = newLocation;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].Location = newLocation;
                    break;
                }
            }
        }

        public void updateDescription(Guid id, string newDescription)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["description"] = newDescription;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].Description = newDescription;
                    break;
                }
            }
        }

        public void updateTitle(Guid id, string newTitle)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["title"] = newTitle;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].Title = newTitle;
                    break;
                }
            }
        }

        public void updatePostInterestStatuses(Guid id, InterestStatus status)
        {
            DataRow row = dataSet.Tables["InterestStatuses"].NewRow();
            row["user_id"] = status.UserId.ToString();
            row["post_id"] = status.PostId;
            row["id"] = status.InterestId;
            row["interested"] = status.Interested;

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].addInterestStatus(status);
                    break;
                }
            }
        }


        public void updateContacts(Guid id, string newContacts)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["contacts"] = newContacts;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].Contacts = newContacts;
                    break;
                }
            }
        }

        public void updateType(Guid id, string newType)
        {
            DataRow row = dataSet.Tables["Posts"].Rows.Find(id);
            if (row != null)
            {
                row["type"] = newType;
            }

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id)
                {
                    posts[i].Type = newType;
                    break;
                }
            }
        }


        public List<Post> getAll()
        {
            return posts;
        }


        public Post getById(Guid id)
        {
            for(int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == id) {
                    return posts[i];
                }
            }
            throw new Exception("Post does not exist!");
        }


    }
}
