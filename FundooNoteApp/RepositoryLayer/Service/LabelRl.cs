using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class LabelRl : ILabelRl
    {
        FundooContext fundooContext;
        public LabelRl(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public LabelEntity CreateNewLabel(NewLabel newLabel, long UserId)
        {
            try
            {
                LabelEntity labelEntity = new LabelEntity();
                labelEntity.LabelHeading = newLabel.LabelHeading;
                labelEntity.NoteID = newLabel.NoteID;
                labelEntity.UserId = UserId;
                fundooContext.LabelDetails.Add(labelEntity);
                int result = fundooContext.SaveChanges();
                if(result > 0)
                {
                    return labelEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteLabel(DeleteLabel deleteLabel, long UserId)
        {
            try
            {
                var result = fundooContext.LabelDetails.Where(x => x.LabelID == deleteLabel.LabelID && x.UserId == UserId).FirstOrDefault();
                if(result != null)
                {
                    fundooContext.LabelDetails.Remove(result);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
