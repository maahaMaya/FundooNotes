using CloudinaryDotNet;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RepositoryLayer.Service
{
    public class NoteRl : INoteRl
    {
        FundooContext fundooContext;
        private readonly IConfiguration iConfiguration;
        public NoteRl(FundooContext fundooContext, IConfiguration iConfiguration)
        {
            this.fundooContext = fundooContext;
            this.iConfiguration = iConfiguration;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newNote"></param>
        /// <param name="UserId"></param>
        /// <returns> </returns>
        public NoteEntity CreateNewNote(NewNote newNote, long UserId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                noteEntity.Title = newNote.Title;
                noteEntity.Note = newNote.Note;
                noteEntity.IsArchive = newNote.IsArchive;
                noteEntity.IsPin = newNote.IsPin;
                DateTime createNoteDateTime = DateTime.Now;
                noteEntity.CreatedNoteTime = createNoteDateTime;
                noteEntity.ModifiedNoteTime = createNoteDateTime;
                noteEntity.UserId = UserId;
                fundooContext.NoteDetails.Add(noteEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return noteEntity;
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

        public bool UpdateNote(UpdateNote updateNote, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == updateNote.NoteID && x.UserId == UserId && x.IsTrash == false).FirstOrDefault();
                if(result != null)
                {
                    result.Title = updateNote.Title;
                    result.Note = updateNote.Note;
                    DateTime createNoteDateTime = DateTime.Now;
                    result.ModifiedNoteTime = createNoteDateTime;
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

        public IEnumerable<NoteEntity> RetrieveNotes(RetriveNote retriveNote,long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == retriveNote.NoteID && x.UserId == UserId && x.IsTrash == false);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveAllNotesWithoutArchieve(long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.UserId == UserId && x.IsArchive == false && x.IsTrash == false);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveAllNotesWithArchieve(long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.UserId == UserId && x.IsArchive == true && x.IsTrash == false );
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveAllNotes(long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.UserId == UserId && x.IsTrash == false);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int MoveToTrash(PinTrashArchieveCollab trash, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == trash.NoteID && x.UserId == UserId).FirstOrDefault();
                if (result != null)
                {
                    result.IsTrash = !result.IsTrash;
                    DateTime createNoteDateTime = DateTime.Now;
                    result.ModifiedNoteTime = createNoteDateTime;
                    fundooContext.SaveChanges();
                    return Convert.ToInt16(true) + Convert.ToInt16(!result.IsTrash);
                }
                else
                {
                    return Convert.ToInt16(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteNote(PinTrashArchieveCollab delete, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == delete.NoteID && x.UserId == UserId && x.IsTrash == true).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.NoteDetails.Remove(result);
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
        public bool DeleteAllTrashNote(long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x =>  x.UserId == UserId && x.IsTrash == true);
                if (result != null)
                {
                    foreach(var data in result)
                    {
                        fundooContext.NoteDetails.Remove(data);
                    }
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
        public bool Delete30DaysTrash(long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.UserId == UserId && x.IsTrash == true).FirstOrDefault();
                if (result != null)
                {
                    TimeSpan timeSpan = result.ModifiedNoteTime - DateTime.UtcNow;
                    if(timeSpan.Days == 30)
                    {
                        fundooContext.NoteDetails.Remove(result);
                        fundooContext.SaveChanges();
                        return true;
                    }
                    return false;
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
        public int PinNote(PinTrashArchieveCollab pin, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == pin.NoteID && x.UserId == UserId && x.IsTrash == false).FirstOrDefault();
                if (result != null)
                {
                    result.IsPin = !result.IsPin;
                    result.ModifiedNoteTime = DateTime.Now;
                    fundooContext.SaveChanges();
                    return Convert.ToInt16(true) + Convert.ToInt16(!result.IsPin);
                }
                else
                {
                    return Convert.ToInt16(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ArchieveNote(PinTrashArchieveCollab archieve, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == archieve.NoteID && x.UserId == UserId && x.IsTrash == false ).FirstOrDefault();
                if (result != null)
                {
                    result.IsArchive = !result.IsArchive;
                    result.ModifiedNoteTime = DateTime.Now;
                    fundooContext.SaveChanges();
                    return Convert.ToInt16(true) + Convert.ToInt16(!result.IsArchive);
                }
                else
                {
                    return Convert.ToInt16(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public bool NoteColor(NoteColor noteColor, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == noteColor.NoteID && x.UserId == UserId && x.IsTrash == false).FirstOrDefault();
                if(result != null)
                {
                    result.Color = noteColor.Color;
                    result.ModifiedNoteTime = DateTime.Now;
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
        public bool ImageUploadOnCloudinary_UpdateImg(NoteBgImage fileUpload, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == fileUpload.NoteID && x.UserId == UserId && x.IsTrash == false).FirstOrDefault();
                if(result != null) 
                {
                    Account account = new Account(
                        this.iConfiguration["CloudinarySettings:CloudName"],
                        this.iConfiguration["CloudinarySettings:ApiKey"],
                        this.iConfiguration["CloudinarySettings:ApiSecret"]
                        );

                    Cloudinary cloudinary = new Cloudinary(account);
                    var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
                    {
                        File = new FileDescription(fileUpload.ImgFile.FileName, fileUpload.ImgFile.OpenReadStream()),
                       
                    };

                    var uploadResult = cloudinary.Upload(uploadParams);
                    string imagePath = uploadResult.Url.ToString();

                    result.Image = imagePath;
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
