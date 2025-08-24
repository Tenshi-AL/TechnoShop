# Product models
![mermaid-diagram-2025-08-24-141128.png](mermaid-diagram-2025-08-24-141128.png)

## CPU specification
| Поле                 | Тип     | Описание                              |
|----------------------|---------|---------------------------------------|
| `ProductID`          | GUID FK | Ссылка на товар                       |
| `SocketType`         | string  | Socket AM5                            |
| `BaseFrequencyGHz`   | decimal | Базовая частота, ГГц                  |
| `MaxFrequencyGHz`    | decimal | Максимальная частота, ГГц             |
| `L3CacheMB`          | int     | Объем кеш-памяти L3, МБ               |
| `CoresCount`         | int     | Количество ядер                       |
| `ThreadsCount`       | int     | Количество потоков                    |
| `ProcessNM`          | int     | Технологический процесс, нм           |
| `TDP_W`              | int     | Базовое тепловыделение, Вт            |
| `MemoryType`         | string  | Тип поддерживаемой памяти, DDR5-5200  |
| `MemoryChannels`     | int     | Количество каналов памяти             |
| `IntegratedGPU`      | boolean | Есть ли интегрированная графика       |
| `HyperThreading`     | boolean | Поддержка многопоточности             |
| `UnlockedMultiplier` | boolean | Разблокированный множитель            |
| `PackageType`        | string  | Tray/Box/MPK                          |
| `IncludedCooler`     | string  | Кулер в комплекте (если есть)         |

## Motherboard specification
| Поле                    | Тип     | Описание                                              |
|-------------------------|---------|-------------------------------------------------------|
| `ProductID`             | GUID FK | Ссылка на PRODUCT                                     |
| `BrandID`               | GUID FK | Ссылка на бренд (например, `MOTHERBOARD_BRAND`)       |
| `CPU_SocketID`          | GUID FK | Ссылка на таблицу `SOCKET_TYPE`                       |
| `Chipset`               | string  | Чипсет (`AMD B850`)                                   |
| `ChipsetCooling`        | string  | Охлаждение чипсета (`радиатор`)                       |
| `VRMCooling`            | string  | Охлаждение VRM (`радиатор`)                           |
| `DIMMSlots`             | string  | Количество и тип DIMM (`4xDDR5 8000+ МГц, до 192 ГБ`) |
| `PCIe_x16`              | string  | PCIe x16 слоты (`1x PCIe 5.0 x16, 1x PCIe 4.0 x16`)   |
| `PCIe_x1`               | int     | PCIe x1 слоты (`2`)                                   |
| `MotherboardPower`      | string  | 24-pin питание (`1x24pin`)                            |
| `CPU_Power`             | string  | 8-pin питание (`2x8pin`)                              |
| `FanHeaders`            | int     | Количество FAN (`7`)                                  |
| `M2Slots`               | int     | Количество M.2 слотов (`3`)                           |
| `M2Type`                | string  | Тип M.2 (`1x PCIe 5.0 x4, 2x PCIe 4.0 x4`)            |
| `SATA3`                 | int     | SATA 3.0 порты (`4`)                                  |
| `AudioCodec`            | string  | Аудиокодек (`Realtek ALC1220P 7.1`)                   |
| `Ethernet`              | string  | Ethernet (`Realtek 2,5GbE`)                           |
| `RearLAN`               | int     | LAN порты на задней панели (`1`)                      |
| `RearAudio`             | int     | Аудио порты на задней панели (`5`)                    |
| `VideoOutputs`          | string  | Выходы для монитора (`1xHDMI, 1xDisplayPort`)         |
| `RearUSB3_2Gen2x2TypeC` | int     | USB 3.2 Gen2x2 Type-C (`1`)                           |
| `RearUSB3_2Gen2TypeA`   | int     | USB 3.2 Gen2 Type-A (`3`)                             |
| `RearUSB3_2Gen1TypeA`   | int     | USB 3.2 Gen1 Type-A (`4`)                             |
| `RearUSB2_0`            | int     | USB 2.0 порты (`2`)                                   |
| `OnboardUSB3_2Gen2`     | string  | USB 3.2 Gen2 на плате (`1x Type-C`)                   |
| `OnboardUSB3_2Gen1`     | string  | USB 3.2 Gen1 на плате (`1 (2 порту)`)                 |
| `OnboardUSB2_0`         | string  | USB 2.0 на плате (`2 (4 порту)`)                      |
| `FormFactor`            | string  | Форм-фактор (`ATX, 305x244 мм`)                       |
| `RAIDSupport`           | string  | Поддержка RAID (`0/1/5/10`)                           |
| `WiFiAdapter`           | string  | Wi-Fi адаптер (`802.11be`)                            |
| `BluetoothAdapter`      | string  | Bluetooth (`5.4`)                                     |
| `ReinforcedPCIESlot`    | boolean | Есть ли усиленный слот PCI-E                          |
| `M2Cooling`             | boolean | Есть ли охлаждение SSD M.2                            |
| `BIOSFlashBack`         | boolean | Поддержка BIOS FlashBack                              |
| `Misc`                  | string  | Дополнительно (`ASUS AI Advisor`)                     |
| `BrandURL`              | string  | Ссылка на бренд-страницу                              |

## GPU specification
| Поле                  | Тип     | Описание                                           |
|-----------------------|---------|----------------------------------------------------|
| `ProductID`           | GUID FK | Ссылка на PRODUCT                                  |
| `BrandID`             | GUID FK | Ссылка на таблицу GPU\_BRAND                       |
| `GPUManufacturerID`   | GUID FK | Ссылка на производителя GPU (AMD, NVIDIA)          |
| `GPUModel`            | string  | Модель GPU (`Radeon RX 9070 XT`)                   |
| `VRAM_GB`             | int     | Объём видеопамяти, ГБ                              |
| `MemoryType`          | string  | Тип памяти (`GDDR6`)                               |
| `Interface`           | string  | Интерфейс PCIe (`PCI Express 5.0`)                 |
| `CoolingSystem`       | string  | Система охлаждения (`air`)                         |
| `FanCount`            | int     | Количество вентиляторов (`3`)                      |
| `Backplate`           | boolean | Есть ли бекплейт                                   |
| `ZeroFanIdle`         | boolean | Остановка вентиляторов в простое                   |
| `MemorySpeedGbps`     | decimal | Скорость памяти, Gbps (`20`)                       |
| `MemoryBusBit`        | int     | Шина памяти, бит (`256`)                           |
| `StreamProcessors`    | int     | Количество потоковых процессоров (`4096`)          |
| `HDMI_Count`          | int     | Количество HDMI портов (`1`)                       |
| `HDMI_Version`        | string  | Версия HDMI (`2.1b`)                               |
| `DisplayPort_Count`   | int     | Количество DisplayPort (`3`)                       |
| `DisplayPort_Version` | string  | Версия DisplayPort (`2.1a`)                        |
| `Dimensions_mm`       | string  | Размеры карты (`312x130x50`)                       |
| `SlotCount`           | decimal | Количество занимаемых слотов (`2,5`)               |
| `ExtraPower`          | string  | Доп. питание (`3x8pin`)                            |
| `RecommendedPSU_W`    | int     | Рекомендованная мощность блока питания (`750`)     |
| `MaxResolution`       | string  | Максимальная разрешающая способность (`7680x4320`) |

## SSD specification
| Поле                | Тип     | Описание                                                  |
|---------------------|---------|-----------------------------------------------------------|
| `ProductID`         | GUID FK | Ссылка на PRODUCT                                         |
| `BrandID`           | GUID FK | Ссылка на таблицу SSD\_BRAND                              |
| `Series`            | string  | Серия SSD (`NV3`)                                         |
| `CapacityGB`        | int     | Объём памяти, ГБ (`1000`)                                 |
| `Interface`         | string  | Интерфейс (`M.2 (PCI-E 4.0)`)                             |
| `NANDType`          | string  | Тип флеш-памяти (`3D NAND`)                               |
| `TRIMSupport`       | boolean | Поддержка TRIM                                            |
| `FormFactor`        | string  | Форм-фактор (`M.2 2280`)                                  |
| `Dimensions_mm`     | string  | Размеры (`80x22x2.3`)                                     |
| `Weight_g`          | int     | Вес, граммы (`7`)                                         |
| `MaxReadMBs`        | int     | Максимальная скорость чтения, МБ/с (`6000`)               |
| `MaxWriteMBs`       | int     | Максимальная скорость записи, МБ/с (`4000`)               |
| `TBW`               | int     | Ресурс записи, TB (`320`)                                 |
| `MTBF_MillionHours` | decimal | Среднее время наработки на отказ (MTBF), млн. часов (`2`) |
| `BrandURL`          | string  | Ссылка на сайт бренда                                     |

## PSU specification
| Поле                   | Тип     | Описание                         |
|------------------------|---------|----------------------------------|
| `ProductID`            | GUID FK | Ссылка на PRODUCT                |
| `BrandID`              | GUID FK | Ссылка на PSU\_BRAND             |
| `FormFactorID`         | GUID FK | Ссылка на PSU\_FORM\_FACTOR      |
| `TotalPower_W`         | int     | Суммарная мощность, Вт           |
| `Power_3_3_5V_W`       | int     | Мощность по каналам +3.3V и +5V  |
| `Power_12V_W`          | decimal | Суммарная мощность по +12V       |
| `Current_5V_A`         | decimal | Ток по +5V                       |
| `Current_3_3V_A`       | decimal | Ток по +3.3V                     |
| `Current_12V1_A`       | decimal | Ток по +12V1                     |
| `Current_minus12V_A`   | decimal | Ток по -12V                      |
| `Current_5Vsb_A`       | decimal | Ток по +5Vsb                     |
| `MotherboardConnector` | string  | Разъем питания материнской платы |
| `CPUConnector`         | string  | Разъем питания CPU               |
| `MolexCount`           | int     | Количество Molex                 |
| `SATA_Count`           | int     | Количество SATA                  |
| `GPUConnector`         | string  | Доп. питание для видеокарт       |
| `InputVoltageRange_V`  | string  | Входное напряжение               |
| `APFC`                 | boolean | Функция APFC                     |
| `EfficiencyStandard`   | string  | Стандарт 80 PLUS                 |
| `EfficiencyPercent`    | decimal | ККД                              |
| `ATXStandard`          | string  | Стандарт ATX12V                  |
| `ModularCables`        | boolean | Модульное подключение кабелей    |
| `SemiPassiveCooling`   | boolean | Напівпасивное охлаждение         |
| `Dimensions_mm`        | string  | Размеры блока                    |
| `Fan_mm`               | int     | Размер вентилятора               |
| `Notes`                | string  | Примечания                       |
| `BrandURL`             | string  | Ссылка на сайт бренда            |

## RAM specification
| Поле           | Тип     | Описание                                |
|----------------|---------|-----------------------------------------|
| `ProductID`    | GUID FK | Ссылка на PRODUCT                       |
| `BrandID`      | GUID FK | Ссылка на RAM\_BRAND                    |
| `CapacityGB`   | int     | Объём памяти, ГБ (`32`)                 |
| `ModuleCount`  | int     | Количество планок в комплекте (`2`)     |
| `Type`         | string  | Тип памяти (`DDR4`, `DDR5`)             |
| `FrequencyMHz` | int     | Эффективная частота (`3200`)            |
| `Timings`      | string  | Штатные тайминги (`CL16`)               |
| `Voltage_V`    | decimal | Рабочее напряжение (`1.35`)             |
| `Heatsinks`    | boolean | Есть радиаторы                          |
| `XMP`          | string  | Поддержка XMP (`XMP 2.0`)               |
| `Rank`         | string  | Ранг памяти (`2Rx8`)                    |
| `ECC`          | string  | Проверка и коррекция ошибок (`non-ECC`) |
| `Buffered`     | string  | Буферизация (`Unbuffered`)              |
| `Color`        | string  | Цвет модулей (`черный`)                 |
| `BrandURL`     | string  | Ссылка на сайт бренда (опционально)     |


## Mermaid code for this model
```
erDiagram

    %% Основная таблица продуктов
    Product {
            GUID ProductID PK
            string Name
            decimal Price
            boolean InStock
            datetime AddedDate
    }
    %% Связи продуктов
    Product ||--o{ Processor : inherit
    Product ||--o{ MOTHERBOARD : inherit
    Product ||--o{ GPU : inherit
    Product ||--o{ SSD : inherit
    Product ||--o{ PSU_SPECS : inherit
    Product ||--o{ RAM_SPECS : inherit

    %% Спецификации CPU
    Processor {
        GUID ProductID FK
        GUID SocketID FK
        GUID BrandID FK
        GUID MemoryTypeID FK
        decimal BaseFrequencyGHz
        decimal MaxFrequencyGHz
        int L3CacheMB
        int CoresCount
        int ThreadsCount
        int ProcessNM
        int TDP_W
        int MemoryChannels
        boolean IntegratedGPU
        boolean HyperThreading
        boolean UnlockedMultiplier
    }
    %% Связи процессоров
    Processor ||--o{ BrandProcessor : has
    Processor ||--o{ Socket : has
    Processor ||--o{ MemoryType : has

    %% Типы памяти
    MemoryType{
        GUID BrandId PK
        string Name
    }

    %% Бренды процессоров
    BrandProcessor{
        GUID BrandId PK
        string Name
    }
    %% Сокеты процессоров и материнских плат
    Socket{
        GUID BrandId PK
        string Name
    }
    

    %% Видеокарта
     MOTHERBOARD{
        GUID ProductID FK
        GUID BrandID FK
        GUID SocketID FK
        GUID ChipsetID FK
        string ChipsetCooling
        string VRMCooling
        string DIMMSlots
        string PCIe_x16
        int PCIe_x1
        string MotherboardPower
    }
    %% Связи мат. плат
    MOTHERBOARD ||--o{ Socket : inherit
    MOTHERBOARD_BRAND ||--o{ MOTHERBOARD : has
    CHIPSET ||--o{ MOTHERBOARD : defines

    %% Таблица брендов материнских плат
    MOTHERBOARD_BRAND {
        GUID BrandID PK
        string BrandName
    }
     %% Таблица чипсетов
    CHIPSET {
        GUID ChipsetID PK
        string ChipsetName
    }
    
    %% Спецификации видеокарт
    GPU {
        GUID ProductID FK
        GUID BrandID FK
        GUID GPUManufacturerID FK
        GUID MemoryTypeID FK
        string GPUModel
        int VRAM_GB
        string Interface
        string CoolingSystem
        int FanCount
        boolean Backplate
        boolean ZeroFanIdle
        decimal MemorySpeedGbps
        int MemoryBusBit
        int StreamProcessors
        int HDMI_Count
        string HDMI_Version
        int DisplayPort_Count
        string DisplayPort_Version
        string Dimensions_mm
        decimal SlotCount
        string ExtraPower
        int RecommendedPSU_W
        string MaxResolution
    }
    %% Связи
    GPU_BRAND ||--o{ GPU : has
    GPU_MANUFACTURER ||--o{ GPU : manufactures
    MemoryType ||--o{ GPU : manufactures

    %% Таблица брендов видеокарт
    GPU_BRAND {
        GUID BrandID PK
        string BrandName
    }

    %% Производитель GPU (чип)
    GPU_MANUFACTURER {
        GUID ManufacturerID PK
        string ManufacturerName
    }

    %% Таблица брендов SSD
    SSD_BRAND {
        GUID BrandID PK
        string BrandName
    }
    %% Спецификации SSD
    SSD {
        GUID ProductID FK
        GUID BrandID FK
        string Series
        int CapacityGB
        string Interface
        string NANDType
        boolean TRIMSupport
        string FormFactor
        string Dimensions_mm
        int Weight_g
        int MaxReadMBs
        int MaxWriteMBs
        int TBW
        decimal MTBF_MillionHours
        string BrandURL
    }

    %% Связи
    SSD ||--o{ SSD_BRAND : hasэ

    %% Таблица брендов PSU
    PSU_BRAND {
        GUID BrandID PK
        string BrandName
    }

    %% Таблица форм-факторов PSU
    PSU_FORM_FACTOR {
        GUID FormFactorID PK
        string FormFactorName
    }
    
    %% Спецификации PSU
    PSU_SPECS {
        GUID ProductID FK
        GUID BrandID FK
        GUID FormFactorID FK
        int TotalPower_W
        int Power_3_3_5V_W
        decimal Power_12V_W
        decimal Current_5V_A
        decimal Current_3_3V_A
        decimal Current_12V1_A
        decimal Current_minus12V_A
        decimal Current_5Vsb_A
        string MotherboardConnector
        string CPUConnector
        int MolexCount
        int SATA_Count
        string GPUConnector
        string InputVoltageRange_V
        boolean APFC
        string EfficiencyStandard
        decimal EfficiencyPercent
        string ATXStandard
        boolean ModularCables
        boolean SemiPassiveCooling
        string Dimensions_mm
        int Fan_mm
        string Notes
        string BrandURL
    }

    %% Связи
    PSU_BRAND ||--o{ PSU_SPECS : has
    PSU_FORM_FACTOR ||--o{ PSU_SPECS : defines
    
    %% Таблица брендов RAM
    RAM_BRAND {
        GUID BrandID PK
        string BrandName
    }

    %% Спецификации оперативной памяти
    RAM_SPECS {
        GUID ProductID FK
        GUID BrandID FK
        int CapacityGB
        int ModuleCount
        string Type
        int FrequencyMHz
        string Timings
        decimal Voltage_V
        boolean Heatsinks
        string XMP
        string Rank
        string ECC
        string Buffered
        string Color
        string BrandURL
    }

    %% Связи
    RAM_BRAND ||--o{ RAM_SPECS : has
```