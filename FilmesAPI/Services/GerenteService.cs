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
    public class GerenteService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);

            _context.Gerentes.Add(gerente);

            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> RecuperarGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();

            if (gerentes != null)
            {
                List<ReadGerenteDto> readDto = _mapper.Map<List<ReadGerenteDto>>(gerentes);

                return readDto;
            }
            else
            {
                return null;
            }
        }

        public ReadGerenteDto RecuperarGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(cinema => cinema.Id == id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                gerenteDto.HoraDaConsulta = DateTime.Now;

                return gerenteDto;
            }

            return null;
        }

        public Result AtualizaGerente(int id, UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            else
            {
                _mapper.Map(gerenteDto, gerente);

                _context.SaveChanges();

                return Result.Ok();
            }
        }

        public Result DeleteGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            else
            {
                _context.Remove(gerente);

                _context.SaveChanges();

                return Result.Ok();
            }
        }
    }
}
