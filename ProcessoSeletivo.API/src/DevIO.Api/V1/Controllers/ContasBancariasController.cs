using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.Extensions;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contasbancarias")]
    public class ContasBancariasController : MainController
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IContaBancariaService _contaBancariaService;
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IMapper _mapper;

        public ContasBancariasController(INotificador notificador,
                                  IBancoRepository bancoRepository,
                                  IContaBancariaRepository contaBancariaRepository,
                                  IContaBancariaService contaBancariaService, 
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _bancoRepository = bancoRepository;
            _contaBancariaService = contaBancariaService;
            _contaBancariaRepository = contaBancariaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContaBancariaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContaBancariaViewModel>>(await _contaBancariaRepository.ObterContasBancarias());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContaBancariaViewModel>> ObterPorId(Guid id)
        {
            var contaBancariaViewModel = _mapper.Map<ContaBancariaViewModel>(await _contaBancariaRepository.ObterContaBancariaPorId(id));

            if (contaBancariaViewModel == null) return NotFound();

            return contaBancariaViewModel;
        }

        [HttpGet("obter-bancos")]
        public async Task<IEnumerable<BancoViewModel>> ObterTodosOsBancos()
        {
            return _mapper.Map<IEnumerable<BancoViewModel>>(await _bancoRepository.ObterTodos());
        }

        [HttpPost]
        public async Task<ActionResult<ContaBancariaViewModel>> Adicionar(ContaBancariaViewModel contaBancariaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _contaBancariaService.Adicionar(_mapper.Map<ContaBancaria>(contaBancariaViewModel));

            return CustomResponse(contaBancariaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ContaBancariaViewModel>> Atualizar(Guid id, ContaBancariaViewModel contaBancariaViewModel)
        {
            if (id != contaBancariaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var contaBancariaAtualizacao = await _contaBancariaRepository.ObterContaBancariaPorId(id);
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            contaBancariaAtualizacao.MapearNovosDados(_mapper.Map<ContaBancaria>(contaBancariaViewModel));

            await _contaBancariaService.Atualizar(contaBancariaAtualizacao);

            return CustomResponse(_mapper.Map<ContaBancariaViewModel>(contaBancariaAtualizacao));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ContaBancariaViewModel>> Excluir(Guid id)
        {
            var contaBancaria = await _contaBancariaRepository.ObterContaBancariaPorId(id);

            if (contaBancaria == null) return NotFound();

            await _contaBancariaService.Remover(id);

            return CustomResponse(_mapper.Map<ContaBancariaViewModel>(contaBancaria));
        }
    }
}