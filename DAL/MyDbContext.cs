using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MODEL;

namespace DAL
{
    public class MyDbContext:DbContext
    {
        public MyDbContext():base("Name=zifuchuan")
        {
        }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Custom>  Custom { get; set; }
        public virtual DbSet<DepartMent> DepartMent { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieHall> MovieHall { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<SessionS> SessionS { get; set; }
    }
}