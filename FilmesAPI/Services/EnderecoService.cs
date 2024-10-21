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
    public class EnderecoService
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionarEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);

            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperarFilmes()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();

            if (enderecos != null)
            {
                List<ReadEnderecoDto> readDto = _mapper.Map<List<ReadEnderecoDto>>(enderecos);

                return readDto;
            }
            else
            {
                return null;
            }
        }

        public ReadEnderecoDto RecuperarEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                enderecoDto.HoraDaConsulta = DateTime.Now;

                return enderecoDto;
            }
            else
            {
                return null;
            }
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            else
            {
                _mapper.Map(enderecoDto, endereco);

                _context.SaveChanges();

                return Result.Ok();
            }
        }

        public Result DeleteEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            else
            {
                _context.Remove(endereco);

                _context.SaveChanges();

                return Result.Ok();
            }
        }
    }
}
