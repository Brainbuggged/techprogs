#include "stdafx.h"



extern "C" __declspec(dllexport) long long   Mul(int* mass, int count)
{
	return Muls(mass, count);

}
extern "C" __declspec(dllexport) long   __stdcall Muls(int* mass, int count)
{
	long ph, pl;

	__asm {

		xor edx, edx
		xor eax, eax
		xor ebx, ebx
		xor esi, esi
		mov esi, mass
		mov eax, 1
		st3:
		mov ebx, edx
			imul   dword ptr[esi]
			mov pl, eax
			mov ph, edx
			mov eax, ebx
			imul dword ptr[esi]
			mov edx, eax
			add edx, ph
			mov eax, pl
			add esi, 4
			dec count
			cmp count, 0
			jne st3
	}


	ph = 0;
	pl = 0;

}


extern "C" __declspec(dllexport)  long  __stdcall Null(int* dim, int  count)
{
	int num = 0;
	__asm
	{
		xor eax, eax
		xor esi, esi
		xor ebx, ebx
		mov esi, dim
		xor edx,edx
		repeas :
			cmp count, 0
			je fin
			mov eax, dword ptr[esi]
			add esi, 4
			cmp eax, 0
			je  plusone
		    dec count
			jmp repeas
			plusone :
		inc  num
			dec count
			cmp count, 0
			je fin
			jmp repeas
			fin :
		mov eax, num

	}




}

extern "C" __declspec(dllexport) void __stdcall Min(int* dim, int count)
{
	long result;
	__asm {

		xor eax, eax
		xor esi, esi
		xor ebx, ebx
		xor edx, edx
		mov esi, dim

		mov eax, dword ptr[esi]
		add esi, 4
		reps:

		mov ebx, dword ptr[esi]
			cmp eax, ebx
			jnle loo1
			dec count
			cmp count, 0
			je fin
			add esi, 4
			jmp reps
			loo1 :
		mov eax, ebx
			dec count
			cmp count, 0
			je fin
			add esi, 4
			jmp reps
			fin :
		mov  esi,dim
			mov dword ptr[esi],eax




	}
	
	

	
	
}


extern "C" __declspec(dllexport)  void  __stdcall MulMas(int* arr1, int* arr2, int array_len)
{
	int i = 0;
	long cont = 0;
	long s = 0;
	__asm
	{

		xor ebx, ebx
		xor ecx, ecx
		xor edx, edx
		xor edi, edi

		mov esi, arr1
		lo :
		mov ecx, i
			mov eax, array_len
			cmp ecx, eax
			je _exi

			mov esi, arr1
			add esi, s
			mov eax, dword ptr[esi]
			mov esi, arr2
			add esi, s
			mov cont, eax
			mov eax, dword ptr[esi]

			imul cont
			mov dword ptr[esi], eax



			add s, 4
			mov ecx, i
			inc ecx
			mov i, ecx
			jmp lo
			_exi :


	}


}