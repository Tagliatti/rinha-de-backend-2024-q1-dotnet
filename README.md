# Rinha backend .NET

## Stack:
- CSharp (C#)
- .NET 8
- Nginx (Load balancer)
- Postgres (Database)

## Stress test
Para o rodar o benchmark, é necessário ter o [gatling](https://gatling.io/docs/gatling/tutorials/installation/)
instalado na máquina, e alterar a variável `GATLING_BIN_DIR` no arquivo `executar-teste-local.sh` com o caminho até a pasta bin do gatling.

Par executar o teste basta digitar o comando:
```bash
./executar-teste-local.sh
```

## Ultimo benchmark
![benchmark-1.png](resources/benchmark-1.png)
![benchmark-2.png](resources/benchmark-2.png)