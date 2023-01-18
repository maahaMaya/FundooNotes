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
    public class CollaboratorRl : ICollaboratorRl
    {
        FundooContext fundooContext;
        public CollaboratorRl(FundooContext fundooContext)
        {
                this.fundooContext = fundooContext;
        }

        public CollabEntity AddCollaborator(AddCollaborator addCollaborator, long UserId)
        {
            try
            {
                var noteResult = fundooContext.NoteDetails.Where(x => x.NoteID == addCollaborator.NoteID && x.UserId == UserId).FirstOrDefault();
                var emailResult = fundooContext.UserDetails.Where(x => x.Email == addCollaborator.Email).FirstOrDefault();
                if (emailResult != null && noteResult != null)
                {
                    CollabEntity collabEntity = new CollabEntity();
                    collabEntity.Email = emailResult.Email;
                    collabEntity.NoteID = noteResult.NoteID;
                    collabEntity.UserId = emailResult.UserId;

                    fundooContext.Add(collabEntity);
                    fundooContext.SaveChanges();
                    return collabEntity;
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

        public IEnumerable<CollabEntity> RetrieveAllCollaborate(PinTrashArchieveCollab NoteTableId, long UserId)
        {
            try
            {
                var resultNoteId = fundooContext.NoteDetails.Where(x => x.NoteID == NoteTableId.NoteID && x.UserId == UserId).FirstOrDefault();
                var result = fundooContext.CollabDetails.Where(x => x.NoteID == resultNoteId.NoteID);
                if (result != null)
                {
                    return result;
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

    }
}
