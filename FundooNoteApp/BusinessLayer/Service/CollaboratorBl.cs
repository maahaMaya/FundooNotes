using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CollaboratorBl : ICollaboratorBl
    {
        ICollaboratorRl iCollaboratorRl;
        public CollaboratorBl(ICollaboratorRl iCollaboratorRl) 
        {
            this.iCollaboratorRl = iCollaboratorRl;
        }

        public CollabEntity AddCollaborator(AddCollaborator addCollaborator, long UserId)
        {
            try
            {
                return iCollaboratorRl.AddCollaborator(addCollaborator, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
