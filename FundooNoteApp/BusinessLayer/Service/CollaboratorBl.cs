using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
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

        public CollabEntity AddCollaborator(AddDeleteCollaborator addCollaborator, long UserId)
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

        public IEnumerable<CollabEntity> RetrieveAllCollaborate(PinTrashArchieveCollab NoteTableId, long UserId)
        {
            try
            {
                return iCollaboratorRl.RetrieveAllCollaborate(NoteTableId, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCollaborate(AddDeleteCollaborator deleteCollaborator, long UserId)
        {
            try
            {
                return iCollaboratorRl.DeleteCollaborate(deleteCollaborator, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
