using System;
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Collections.Generic;


namespace BeerTimes
{
    public class MyBeerLocal
    {
        [PrimaryKey]
        public string id { get; set; }
        public string name { get; set; }
        public bool onwishlist { get; set; }
        public Int16 rating { get; set; }
        public string comment { get; set; }

        public void save()
        {
            try
            {
                SQLiteConnection localconn = LocalDataHelper.GetConnection();
                var newBeer = new MyBeerLocal() {
                    id = this.id,
                    name = this.name,
                    rating = this.rating,
                    comment = this.comment,
                    onwishlist = this.onwishlist
                };

                if (GetMyBeerById(this.id) == null)
                    localconn.Insert(newBeer);
                else
                    localconn.Update(newBeer);

            }
            catch (Exception ex)
            {
                //Utility.LogException("MathwayMobile.MathwayUser.saveLocal", ex);
            }
        }

        public static List<MyBeerLocal> GetMyBeers()
        {
            try {
                SQLiteConnection localconn = LocalDataHelper.GetConnection();
                string query = "select * from MyBeerLocal where onwishlist = 0" ;
                List<MyBeerLocal> result = localconn.Query<MyBeerLocal>(query);
                return result;
            }
            catch (Exception ex)
            {
                return new List<MyBeerLocal>();
                //todo

            }
        }

        public static List<MyBeerLocal> GetWishlistBeers()
        {
            try
            {
                SQLiteConnection localconn = LocalDataHelper.GetConnection();
                string query = "select * from MyBeerLocal where onwishlist = 1";
                List<MyBeerLocal> result = localconn.Query<MyBeerLocal>(query);
                return result;
            }
            catch (Exception ex)
            {
                return new List<MyBeerLocal>();
                //todo

            }
        }

        public static MyBeerLocal GetMyBeerById(string id)
        {
            try
            {
                SQLiteConnection localconn = LocalDataHelper.GetConnection();
                string query = "select * from MyBeerLocal where id = '" + id + "'";

                List<MyBeerLocal> result = localconn.Query<MyBeerLocal>(query);
                if (result.Count > 0)
                    return result[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                //todo

            }
        }

        public static void BuildMockBeerList()
        {
            MyBeerLocal b = new MyBeerLocal() {
                id = "1",
                name = "beer 1",
                rating = 2,
                comment = "comment 1"
            };

            b.save();



        }

    }

    public class WishlistLocal
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
