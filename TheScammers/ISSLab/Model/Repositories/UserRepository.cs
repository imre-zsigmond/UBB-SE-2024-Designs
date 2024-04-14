using ISSLab.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ISSLab.Model.Repositories
{
    class UserRepository
    {
        private readonly DataSet dataSet;
        private readonly string connectionString;
        List<User> users;

        public UserRepository()
        {
            dataSet = new DataSet();
            connectionString = "Data Source=DESKTOP-1VJ4V0K;Initial Catalog=ISSLab;Integrated Security=True";
            users = new List<User>();
        }
        public UserRepository(DataSet _dataSet)
        {
            dataSet = _dataSet;
            connectionString = "";
            users = new List<User>();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    string selectAllUsersQuery = "SELECT * FROM Users";
            //    string selectAllGroupsWithSellingPrivelage = "SELECT * FROM UsersAndGroupsWithSellingPrivelage";
            //    string selectAllGroupsWithRequestToSell = "SELECT * FROM UsersAndGroupsWithRequestToSell";
            //    string selectAllCarts = "SELECT * FROM Carts";
            //    string selectAllFavorites = "SELECT * FROM Favorites";
            //    string selectAllMembers = "SELECT * FROM Members";
            //    string selectAllReviews = "SELECT * FROM Reviews";
            //    string selectAllPosts = "SELECT * FROM Posts";
            //    SqlDataAdapter usersDataAdapter = new SqlDataAdapter(selectAllUsersQuery, connection);
            //    SqlDataAdapter groupsWithSellingPrivelageDataAdapter = new SqlDataAdapter(selectAllGroupsWithSellingPrivelage, connection);
            //    SqlDataAdapter groupsWithRequestToSell = new SqlDataAdapter(selectAllGroupsWithRequestToSell, connection);
            //    SqlDataAdapter cartsDataAdapter = new SqlDataAdapter(selectAllCarts, connection);
            //    SqlDataAdapter favoritesDataAdapter = new SqlDataAdapter(selectAllFavorites, connection);
            //    SqlDataAdapter membersDataAdapter = new SqlDataAdapter(selectAllMembers, connection);
            //    SqlDataAdapter reviewsDataAdapter = new SqlDataAdapter (selectAllReviews, connection);
            //    SqlDataAdapter postsDataAdapter = new SqlDataAdapter(selectAllPosts, connection);
            //    usersDataAdapter.Fill(dataSet, "Users");
            //    groupsWithSellingPrivelageDataAdapter.Fill(dataSet, "UsersAndGroupsWithSellingPrivelage");
            //    groupsWithRequestToSell.Fill(dataSet, "UsersAndGroupsWithRequestToSell");
            //    cartsDataAdapter.Fill(dataSet, "Carts");
            //    favoritesDataAdapter.Fill(dataSet, "Favorites");
            //    membersDataAdapter.Fill(dataSet, "Members");
            //    reviewsDataAdapter.Fill(dataSet, "Reviews");
            //    postsDataAdapter.Fill(dataSet, "Posts");

            //    DataTable usersTable = dataSet.Tables["Users"];
            //    DataTable sellingPrivelageTable = dataSet.Tables["UsersAndGroupsWithSellingPrivelage"];
            //    DataTable requestToSellTable = dataSet.Tables["UsersAndGroupsWithRequestToSell"];
            //    DataTable cartsTable = dataSet.Tables["Carts"];
            //    DataTable favoritesTable = dataSet.Tables["Favorites"];
            //    DataTable membersTable = dataSet.Tables["Members"];
            //    DataTable reviewsTable = dataSet.Tables["Reviews"];
            //    DataTable postsTable = dataSet.Tables["Posts"];

            //    foreach(DataRow row in usersTable.Rows)
            //    {
            //        Guid id = (Guid)row["id"];
            //        string username = (string)row["username"];
            //        string realName = (string)row["real_name"];
            //        DateOnly dateOfBirth = (DateOnly)row["date_of_birth"];
            //        string profilePicture = (string)row["profile_picture"];
            //        string password = (string)row["password"];
            //        DateTime creationDate = (DateTime)row["creation_date"];
            //        int nrOfSells = (int)row["number_of_sells"];
            //        List<Guid> sellPrivelageGroups = new List<Guid>();
            //        List<Guid> requestToSellGroups = new List<Guid>();
            //        List<SellingUserScore> sellingUserScores = new List<SellingUserScore>();
            //        foreach (DataRow row2 in sellingPrivelageTable.Rows)
            //        {
            //            if ((Guid)row2["user_id"] == id)
            //            {
            //                sellPrivelageGroups.Add((Guid)row2["group_id"]);
            //                Guid userScoreId = id;
            //                Guid groupId = (Guid)row2["group_id"];
            //                int score = (int)row2["score"];
            //                SellingUserScore sellingUserScore = new SellingUserScore(userScoreId, groupId, score);
            //                sellingUserScores.Add(sellingUserScore);
            //            }
            //        }
            //        foreach(DataRow row3 in requestToSellTable.Rows)
            //        {
            //            if ((Guid)row3["user_id"] == id)
            //            {
            //                requestToSellGroups.Add((Guid)row3["group_id"]);
            //            }
            //        }
            //        List<Guid> groups = new List<Guid>();
            //        List<Cart> carts = new List<Cart>();
            //        foreach (DataRow row2 in membersTable.Rows)
            //        {
            //            if ((Guid)row2["user_id"] == id)
            //            {
            //                Guid groupId = (Guid)row2["group_id"];
            //                groups.Add(groupId);
            //                List<Guid> posts = new List<Guid>();
            //                foreach (DataRow row3 in cartsTable.Rows)
            //                {
            //                    if ((Guid)row3["user_id"] == id)
            //                    {
            //                        Guid cartUserId = (Guid)row3["user_id"];
            //                        if ((Guid)row3["group_id"] == groupId)
            //                        {
            //                            Guid cartGroupId = (Guid)row3["group_id"];
            //                            //foreach(DataRow row4 in postsTable.Rows)
            //                            //{
            //                            //    if ((Guid)row4["group_id"] == cartGroupId)
            //                            //    {
            //                            //        Guid postId = (Guid)row4["post_id"];
            //                            //        posts.Add(postId);
            //                            //    }
            //                            //}
            //                            Guid postId = (Guid)row3["post_id"];
            //                            posts.Add(postId);
            //                        }

            //                    }
            //                }
            //                Cart newCart = new Cart(groupId, id, posts);
            //                carts.Add(newCart);
            //            }
            //        }

            //        List<Favorites> favorites = new List<Favorites>();
            //        for(int i = 0; i <= groups.Count; i++)
            //        {
            //            Guid currGroup = groups[i];
            //            List<Guid> posts = new List<Guid>();
            //            foreach (DataRow row2 in favoritesTable.Rows)
            //            {
                            
            //                if ((Guid)row2["user_id"] == id & (Guid)row2["group_id"] == currGroup)
            //                {
            //                    Guid favoritesUserId = (Guid)row2["user_id"];
            //                    Guid favoritesGroupId = (Guid)row2["group_id"];
            //                    posts.Add((Guid)row2["post_id"]);
            //                }
            //            }
            //            Favorites newFavorites = new Favorites(currGroup, id, posts);
            //        }
            //        List<Review> reviews = new List<Review>();
            //        foreach(DataRow row2 in reviewsTable.Rows)
            //        {
            //            if ((Guid)row2["user_id"] == id)
            //            {
            //                Guid reviewId = (Guid)row2["id"];
            //                Guid reviewerId = (Guid)row2["reviewer_id"];
            //                Guid sellerId = (Guid)row2["seller_id"];
            //                Guid groupId = (Guid)row2["group_id"];
            //                String content = (string)row2["content"];
            //                DateTime date = (DateTime)row2["date"];
            //                int rating = (int)row2["rating"];
            //                Review newReview = new Review(reviewId, reviewerId, sellerId,groupId, content, date, rating);
            //                reviews.Add(newReview);
            //            }
            //        }
            //        users.Add(new User(id, username, realName, dateOfBirth, profilePicture, password, creationDate, sellPrivelageGroups, requestToSellGroups, sellingUserScores, carts, favorites, groups, reviews, nrOfSells));
            //    }
            //}
        }
        //private Guid id;
        //private string username;
        //private string realName;
        //private DateOnly dateOfBirth;
        //private string profilePicture;
        //private string password;
        //private DateTime creationDate;
        //private List<Guid> groupsWithSellingPrivelage;
        //private List<Guid> groupsWithActiveRequestToSell;

        public List<User> findAllUsers()
        {
            return users;
        }

        public User findById(Guid id)
        {
            for(int i = 0;  i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    return users[i];
                }
            }
            throw new Exception("User does not exist");
        }
        public void AddUser(User newUser)
        {
            //DataRow newRow = dataSet.Tables["Users"].NewRow();
            //newRow["Id"] = newUser.Id.ToString();
            //newRow["username"] = newUser.Username;
            //newRow["real_name"] = newUser.RealName;
            //newRow["date_of_birth"] = newUser.DateOfBirth;
            //newRow["profile_picture"] = newUser.ProfilePicture;
            //newRow["password"] = newUser.Password;
            //newRow["creation_date"] = newUser.CreationDate;
            //List<Guid> groupsWithSellingPrivelage = newUser.GroupsWithSellingPrivelage;
            //for(int i = 0; i < groupsWithSellingPrivelage.Count; i++)
            //{
            //    DataRow newSellingGroupsRow = dataSet.Tables["UsersAndGroupsWithSellingPrivelage"].NewRow();
            //    newSellingGroupsRow["user_id"] = newUser.Id;
            //    newSellingGroupsRow["group_id"] = groupsWithSellingPrivelage[i];
            //}
            //List<Guid> groupsWithRequestToSell = newUser.GroupsWithActiveRequestToSell;
            //for(int i = 0; i < groupsWithRequestToSell.Count; i++)
            //{
            //    DataRow newSellingRequestGroupsRow = dataSet.Tables["UsersAndGroupsWithRequestToSell"].NewRow();
            //    newSellingRequestGroupsRow["user_id"] = newUser.Id;
            //    newSellingRequestGroupsRow["group_id"] = groupsWithRequestToSell[i];
            //}
            users.Add(newUser);
        }

        public void updateUserUsername(Guid id, string newUsername)
        {
            DataRow row = dataSet.Tables["Users"].Rows.Find(id);
            if (row != null)
            {
                row["username"] = newUsername;
            }

            for(int i = 0; i <  users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users[i].Username = newUsername;
                    break;
                }
            }
        }

        public void updateGroupsWithSellingPrivelage(Guid id, Guid group)
        {
            DataRow row = dataSet.Tables["UsersAndGroupsWithSellingPrivelage"].NewRow();
            row["user_id"] = id.ToString();
            row["group_id"] = group.ToString();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users[i].receivedPrivelageToSell(group);
                    break;
                }
            }
        }

        public void updateGroupsWithSellingRequest(Guid id, Guid group)
        {
            DataRow row = dataSet.Tables["UsersAndGroupsWithRequestToSell"].NewRow();
            row["user_id"] = id.ToString();
            row["group_id"] = group.ToString();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users[i].requestSellingAccess(group);
                    break;
                }
            }
        }

        public void updateGroupsWithRemovingSellingRequest(Guid userId, Guid groupId)
        {
            DataRow row = dataSet.Tables["UsersAndGroupsWithRequestToSell"].Rows.Find((DataRow r) => (string)(r["user_id"]) == userId.ToString() && (string)(r["group_id"]) == groupId.ToString()  );
            if (row != null)
            {
                dataSet.Tables["UsersAndGroupsWithRequestToSell"].Rows.Remove(row);
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == userId)
                {
                    users[i].accessToSellDenied(groupId);
                    break;
                }
            }
        }
        public void updateGroupsWithRemovingSellingPrivelage(Guid userId, Guid groupId)
        {
            DataRow row = dataSet.Tables["UsersAndGroupsWithSellingPrivelage"].Rows.Find((DataRow r) => (string)(r["user_id"]) == userId.ToString() && (string)(r["group_id"]) == groupId.ToString());
            if (row != null)
            {
                dataSet.Tables["UsersAndGroupsWithSellingPrivelage"].Rows.Remove(row);
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == userId)
                {
                    users[i].accessToSellWasTaken(groupId);
                    break;
                }
            }
        }


        public void updateUserRealName(Guid id, string newRealName)
        {
            DataRow row = dataSet.Tables["Users"].Rows.Find(id);
            if (row != null)
            {
                row["real_name"] = newRealName;
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users[i].RealName = newRealName;
                    break;
                }
            }
        }

        public void updateUserDateOfBirth(Guid id, DateOnly newDateOfBirth)
        {
            DataRow row = dataSet.Tables["Users"].Rows.Find(id);
            if (row != null)
            {
                row["date_of_birth"] = newDateOfBirth;
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users[i].DateOfBirth = newDateOfBirth;
                    break;
                }
            }
        }

        public void AddReview(Review review)
        {
            DataRow row = dataSet.Tables["Reviews"].NewRow();
            row["id"] = review.Id;
            row["reviewer_id"] = review.ReviewerId;
            row["seller_id"] = review.SellerId;
            row["group_id"] = review.GroupId;
            row["content"] = review.Content;
            row["date"] = review.Date;
            row["rating"] = review.Rating;
            users.Find(u => u.Id == review.SellerId).AddReview(review);
        }
            
     

        public void updateUserProfilePicture(Guid id, string newProfilePicture)
        {
            DataRow row = dataSet.Tables["Users"].Rows.Find(id);
            if (row != null)
            {
                row["profile_picture"] = newProfilePicture;
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users[i].ProfilePicture = newProfilePicture;
                    break;
                }
            }
        }

        public void updateUserPassword(Guid id, string newPassword)
        {
            DataRow row = dataSet.Tables["Users"].Rows.Find(id);

            if (row != null)
            {
                row["password"] = newPassword;
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users[i].Password = newPassword;
                    break;
                }
            }
        }

        public void updateUserNrOfSells(Guid id, int nrOfSells)
        {
            DataRow row = dataSet.Tables["Users"].Rows.Find(id);

            if (row != null)
            {
                row["number_of_sells"] = nrOfSells;
            }

            for(int i = 0; i < users.Count;i++)
            {
                if (users[i].Id == id)
                {
                    users[i].NrOfSells = nrOfSells;
                    break;
                }
            }
        }

        public void DeleteUser(Guid id)
        {
            DataRow userRow = dataSet.Tables["Users"].Rows.Find(id);
            if (userRow != null)
            {
                userRow.Delete();
            }

            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    users.RemoveAt(i);
                    break;
                }
            }

            DataTable groupsWithSellingPrivelageTable = dataSet.Tables["UsersAndGroupsWithSellingPrivelage"];

            // Create a list to store the rows that match the specified age
            List<DataRow> rowsToDelete = new List<DataRow>();

            // Iterate through each row in the DataTable
            foreach (DataRow row in groupsWithSellingPrivelageTable.Rows)
            {
                // Check if the "Age" column value matches the specified age
                if (row["user_id"] != DBNull.Value && (Guid)row["user_id"] == id)
                {
                    // If the condition is met, add the row to the list of rows to delete
                    rowsToDelete.Add(row);
                }
            }

            // Remove the rows from the DataTable
            foreach (DataRow rowToDelete in rowsToDelete)
            {
                groupsWithSellingPrivelageTable.Rows.Remove(rowToDelete);
            }

            DataTable groupsWithRequestToSellTable = dataSet.Tables["UsersAndGroupsWithRequestToSell"];

            // Create a list to store the rows that match the specified age
            List<DataRow> rowsToDelete2 = new List<DataRow>();

            // Iterate through each row in the DataTable
            foreach (DataRow row in groupsWithRequestToSellTable.Rows)
            {
                // Check if the "Age" column value matches the specified age
                if (row["user_id"] != DBNull.Value && (Guid)row["user_id"] == id)
                {
                    // If the condition is met, add the row to the list of rows to delete
                    rowsToDelete2.Add(row);
                }
            }

            // Remove the rows from the DataTable
            foreach (DataRow rowToDelete in rowsToDelete2)
            {
                groupsWithRequestToSellTable.Rows.Remove(rowToDelete);
            }
        }

        public void addToCart(Guid groupId, Guid userId, Guid postId )
        {
            //DataRow row = dataSet.Tables["Carts"].NewRow();
            //row["user_id"] = userId;
            //row["group_id"] = groupId;
            //row["post_id"] = postId;
            Cart cart = users.Find(user => user.Id == userId).Carts.Find(c => c.GroupId == groupId);
            if(cart == null)
            {
                cart = new Cart(groupId, userId);
                users.Find(user=>user.Id == userId).Carts.Add(cart);
            }
            if (cart.Posts.Contains(postId))
                return;
            cart.Posts.Add(postId);
        }

        public void removeFromCart(Guid groupId, Guid userId, Guid postId)
        {
            DataRow row = dataSet.Tables["Carts"].Rows.Find((DataRow r) => Guid.Parse((string)r["group_id"]) == groupId && Guid.Parse((string)r["user_id"]) == userId && Guid.Parse((string)r["post_id"]) == postId);
            if(row !=  null)
                dataSet.Tables["Carts"].Rows.Remove(row);
            users.Find(u=>u.Id == userId).Carts.Find(c=>c.GroupId==groupId).Posts.Remove(postId);
        }

        public void addToFavorites(Guid groupId, Guid userId, Guid postId)
        {
            //DataRow row = dataSet.Tables["Favorites"].NewRow();
            //row["user_id"] = userId;
            //row["group_id"] = groupId;
            //row["post_id"] = postId;
            Favorites favoriteFromGroup = users.Find(user => user.Id == userId).Favorites.Find(c => c.GroupId == groupId);
            if (favoriteFromGroup == null)
            {
                favoriteFromGroup = new Favorites(userId, groupId);
                users.Find(user => user.Id == userId).Favorites.Add(favoriteFromGroup);
            }
            if (favoriteFromGroup.Posts.Contains(postId))
                return;
            favoriteFromGroup.Posts.Add(postId);
        }

        public void removeFromFavorites(Guid groupId, Guid userId, Guid postId)
        {
            DataRow row = dataSet.Tables["Favorites"].Rows.Find((DataRow r) => Guid.Parse((string)r["group_id"]) == groupId && Guid.Parse((string)r["user_id"]) == userId && Guid.Parse((string)r["post_id"]) == postId);
            if (row != null)
                dataSet.Tables["Favorites"].Rows.Remove(row);
            users.Find(u => u.Id == userId).Carts.Find(c => c.GroupId == groupId).Posts.Remove(postId);
        }

    }
}
