Flappy Bird (WinForms) 
*Küçük ve akıcı bir Flappy Bird klonu. Timer ile oyun döngüsü işler; kuş yerçekimiyle düşer, Space ile zıplar. Borular rastgele yüksekliklerle ekrandan kayar; çarpışma olursa oyun durur ve skor gösterilir.
Özellikler
*WinForms üzerinde basit oyun döngüsü (Interval=20ms)
*Rastgele boru yüksekliği ve aralığı (gap=150)
*Skor takibi, çarpışma algılama, yeniden başlatma
Kontroller
*Space: Kuşu yukarı zıplatır
*R: Oyun bittiyse yeniden başlatır
Çalıştırma
*Projeyi Visual Studio’da Windows Forms App (.NET Framework) olarak açın.
*Form üzerinde bird, pipeTop, pipeBottom, ground, scoreText kontrolleri tanımlı olmalı.
*Programı F5 ile başlatın.
Notlar
*DoubleBuffered açık; titreme minimumdur.
*Pencere yeniden boyutlanınca zemin otomatik hizalanır.
*Kod basit tutuldu; kolayca tema/ hız/ zorluk ayarı eklenebilir.
