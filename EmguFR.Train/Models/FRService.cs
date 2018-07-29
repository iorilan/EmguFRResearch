using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmguFR.Train.Models
{
    public class FRService
    {
        public bool Enroll(UserFace record, out string error)
        {
            error = "";
            try
            {
                using (var context = new EmguFRContext())
                {
                    var existing = context.UserFaces.FirstOrDefault(x => x.UserName == record.UserName);
                    if (existing != null)
                    {
                        context.UserFaces.Remove(existing);
                    }

                    context.UserFaces.Add(record);
                    context.SaveChanges();
                }

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                error = ex.Message;
                if (ex.InnerException != null)
                {
                    error += "\r\n" + ex.InnerException;
                }

                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }

        public IList<UserFace> All()
        {
            try
            {
                using (var context = new EmguFRContext())
                {
                    var all = context.UserFaces.ToList();
                    return all;
                }
            }
            catch (Exception ex)
            {
                return new List<UserFace>();
            }
        }
    }
}
