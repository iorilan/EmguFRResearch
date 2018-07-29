using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace EmguFR.Recognize.Models
{
    public class FRService
    {
        public UserFace GetById(int id)
        {
            try
            {
                using (var context = new EmguFRContext())
                {
                    var record = context.UserFaces.FirstOrDefault(x => x.Id == id);
                    return record;
                }
            }
            catch (Exception ex)
            {
                return new UserFace();
            }
        }
    }
}
