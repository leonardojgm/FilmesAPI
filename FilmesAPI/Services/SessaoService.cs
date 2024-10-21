using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);

            _context.Sessoes.Add(sessao);

            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<ReadSessaoDto> RecuperarSessoes()
        {
            List<Sessao> sessoes = _context.Sessoes.ToList();

            if (sessoes != null)
            {
                List<ReadSessaoDto> readDto = _mapper.Map<List<ReadSessaoDto>>(sessoes);

                return readDto;
            }
            else
            {
                return null;
            }
        }

        public ReadSessaoDto RecuperarSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(cinema => cinema.Id == id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                sessaoDto.HoraDaConsulta = DateTime.Now;

                return sessaoDto;
            }

            return null;
        }

        public Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            else
            {
                _mapper.Map(sessaoDto, sessao);

                _context.SaveChanges();

                return Result.Ok();
            }
        }

        public Result DeleteSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            else
            {
                _context.Remove(sessao);

                _context.SaveChanges();

                return Result.Ok();
            }
        }
    }
}
