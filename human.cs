using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace crud1_human
{
    public class human
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public byte age { get; set; }

        db db1 = new db();
        public bool registeer(human h)
        {
            if (!exist(h))
            {
                db1.humans.Add(h);
                db1.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool exist(human h)
        {
            var a=db1.humans.Where(i=>i.name==h.name&&i.family==h.family).ToList();
            if (a.Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public human reedbyid(int id)
        {
            return db1.humans.Where(i=>i.id==id).FirstOrDefault();
        }
        public List<human> reedbyname(string s)
        {
            byte b = Convert.ToByte(s);
            return db1.humans.Where(i=>i.name.Contains(s)||i.family.Contains(s)||i.age==b).ToList();
        }
        public List<human> reedall()
        {
            return db1.humans.ToList();
        }
        public void delete(int id)
        {
            human h=reedbyid(id);
            db1.humans.Remove(h);
            db1.SaveChanges();
        }
        public void update(int id,human h)
        {
            var a =db1.humans.Where(i=>i.id == id).FirstOrDefault();
            a.name = h.name;
            a.family = h.family;
            a.age = h.age;
            db1.SaveChanges();
        }
    }
}
