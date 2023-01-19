using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class LabelBl : ILabelBl
    {
        ILabelRl iLabelRl;
        public LabelBl(ILabelRl iLabelRl)
        {
            this.iLabelRl = iLabelRl;
        }

        public LabelEntity CreateNewLabel(NewLabel newLabel, long UserId)
        {
            try
            {
                return iLabelRl.CreateNewLabel(newLabel, UserId);
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
                return iLabelRl.DeleteLabel(deleteLabel, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LabelEntity> RetrieveLabel(long UserId)
        {
            try
            {
                return iLabelRl.RetrieveLabel(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
