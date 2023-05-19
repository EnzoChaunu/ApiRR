using AutoMapper;
using Business.Interfaces;
using Commun.dto;
using Commun.Hash;
using Commun.Mapping;
using Commun.Responses;
using DataAccess.Interfaces;
using Nest;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Services
{
    public class CommentService : ICommentsService
    {
        private readonly ICommentRepository _repos;
        private readonly IUserRepo _user;
        private readonly IRessourceRepo _ressource;
        public CommentService(ICommentRepository repo, IUserRepo user, IRessourceRepo ressource)
        {
            _repos = repo;
            _user = user;
            _ressource = ressource;
        }

        public async Task<Response<bool>> Archive(int id)
        {
            var comment = await _repos.Get(id);
            if (comment == null)
            {
                return new Response<bool>
                        (404, false, "Commentaire introuvable.");
            }
            else
            {
                await _repos.Archive(id);
                return new Response<bool>
                        (200, true, 
                        string.Format("Commentaire {0} posté par {1} sur ressource {2} archivé avec succès.", 
                        comment.id_comments, comment.id_user, comment.id_ressource));
            }
        }

        public async Task<Response<CommentDto>> Create(CommentDto obj)
        {
            var expe = await _user.Get(obj.UserId);
            var ress = await _ressource.Get(obj.RessourceId);
            var map = MappingComment.CommentMapperDtoToModel(expe, ress);
            obj.CreationDate = DateTime.Now;
            obj.Activation = true;
            obj.Modified = false;
            var commentDb = map.Map<CommentDto, Comment>(obj);

            var rep = await _repos.Create(commentDb);
            if (rep != null)
            {
                map = MappingComment.CommentMapperModelToDto();
                var comment = map.Map<Comment, CommentDto>(rep);
                return new Response<CommentDto>
                            (200, comment, string.Format("comment {0} posté par {1} sur {2} avec succès!", comment.Id, expe.Email, ress._title));
            }
            else
            {
                return new Response<CommentDto>
                            (500, null, "Erreur de communication avec Db");
            }
        }

        public async Task<Response<CommentDto>> CreateWithToken(CommentDto obj, string expediteur)
        {
            var token = Hashing.HashToken(expediteur);
            var expe = await _user.GetUserByToken(token);
            if(expe != null)
            {
                var ress = await _ressource.Get(obj.RessourceId);
                var map = MappingComment.CommentMapperDtoToModel(expe, ress);
                obj.CreationDate = DateTime.Now;
                obj.Activation = true;
                obj.Modified = false;
                obj.UserId= expe.Id_User;
                var commentDb = map.Map<CommentDto, Comment>(obj);

                var rep = await _repos.Create(commentDb);
                if (rep != null)
                {
                    map = MappingComment.CommentMapperModelToDto();
                    var comment = map.Map<Comment, CommentDto>(rep);
                    return new Response<CommentDto>
                                (200, comment, string.Format("comment {0} posté par {1} sur {2} avec succès!", comment.Id, expe.Email, ress._title));
                }
                else
                {
                    return new Response<CommentDto>
                                (500, null, "Erreur de communication avec Db");
                }
            }
            else
            {
                return new Response<CommentDto>(401, null, "Non-autorisé");
            }
            
        }

        public async Task<Response<CommentDto>> Get(int id)
        {
            var rep = await _repos.Get(id);
            var map = MappingComment.CommentMapperModelToDto();
            if (rep != null)
            {
                var comment = map.Map<Comment, CommentDto>(rep);
                return new Response<CommentDto>
                (200, comment, 
                string.Format("Commentaire {0} posté par {1} sur ressource {2} chargé avec succès.", comment.Id, comment.UserId, comment.RessourceId));
            }
            else
                return new Response<CommentDto>
                (500, null, "Commentaire introuvable");
        }

        public async Task<Response<List<CommentDto>>> GetCommentsPerRessource(int id)
        {
            var res = await _ressource.Get(id);
            if(res != null)
            {
                var rep = await _repos.GetCommentListPerResource(res.ID_Ressource);
                var mapper = MappingComment.CommentMapperModelToDto();
                var comments = mapper.Map<List<Comment>, List<CommentDto>>(rep);
                return new Response<List<CommentDto>>(200, comments, string.Format("Liste des commentaires pour la ressource {0}", res._title));
            }
            else
                return new Response<List<CommentDto>>(200, null, string.Format("Ressource Id : {0} introuvable", id));
        }

        public async Task<Response<List<CommentDto>>> GetCommentsPerUser(int id)
        {
            var user = await _user.Get(id);
            if (user != null)
            {
                var rep = await _repos.GetCommentListPerUser(user.Id_User);
                var mapper = MappingComment.CommentMapperModelToDto();
                var comments = mapper.Map<List<Comment>, List<CommentDto>>(rep);
                return new Response<List<CommentDto>>(200, comments, string.Format("Liste des commentaires pour l'utilisateur {0}", user.Email));
            }
            else
                return new Response<List<CommentDto>>(200, null, string.Format("Ressource Id : {0} introuvable", id));
        }

        public async Task<Response<CommentDto>> Update(CommentDto obj, int id)
        {
            var repToUpdate = await _repos.Get(id);
            
            if (repToUpdate != null)
            {
                var map = MappingComment.CommentMapperModelToDto();
                var commentDb = map.Map<CommentDto, Comment>(obj);
                var rep = await _repos.Update(commentDb, repToUpdate.id_comments);
                if (rep != null)
                {
                    var comment = map.Map<Comment, CommentDto>(rep);
                    return new Response<CommentDto>
                        (200, comment, 
                        string.Format("Commentaire {0} posté par {1} sur ressource {2} modifié", comment.Id, comment.UserId, comment.RessourceId));
                }
                else
                    return new Response<CommentDto>
                            (404, null, "Connexion vers la base de données a échouée.");
            }
            else
                return new Response<CommentDto>
                            (404, null, string.Format("Commentaire {0} introuvable", id));
        }
    }
}
