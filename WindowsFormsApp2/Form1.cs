using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {

        int te;
        public Form1()
        {
            InitializeComponent();
            OgrenciEkle();
        }

        public class Entity
        {
            public ObjectId Id { get; set; }
            public string Name { get; set; }
            public string Soyadi { get; set; }

        }

        static void OgrenciEkle()
        {
            var connectionString = "mongodb://localhost";

            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase("denemedb");
            var ff = db.GetCollection<Entity>("denemecoll");
            var entity = new Entity { Name = "oguz", Soyadi = "rrr" };
            ff.InsertOneAsync(entity);


        }    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            rnd.Next(10000);
            int ee = rnd.Next(0x64);
            label1.Text = ee.ToString();
            this.te = ee;
            timer1.Interval = 100;
            timer1.Start();


        }

        private void button2_ClickAsync(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost";

            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase("denemedb");
            var ff = db.GetCollection<BsonDocument>("denemecoll");
            /*var filter = Builders<Entity>.Filter.Eq("Name", "oguz");
            var filterw = new BsonDocument("FirstName", "Peter");

            var entitys = ff.FindAsync<Entity>(filterw);*/
/*            Console.WriteLine(entitys);
*/
            var document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
                }, { "class_id", 480 }
        };
            ff.InsertOneAsync(document);







        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost";

            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase("denemedb");
            var ff = db.GetCollection<BsonDocument>("denemecoll");
            var firstDocument = ff.Find(new BsonDocument()).FirstOrDefaultAsync();
            /*Console.WriteLine(firstDocument.ToString());*/
            var documents = ff.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                Console.WriteLine(doc.ToString());
                richTextBox1.Text = documents.ToJson();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost";

            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase("denemedb");
            var ff = db.GetCollection<BsonDocument>("denemecoll");
            var filter = Builders<BsonDocument>.Filter.Eq("Name", "oguz");
            var studentDocument = ff.Find(filter).FirstOrDefault();
            Console.WriteLine(studentDocument.ToString());
            richTextBox1.Text = studentDocument.ToString();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
