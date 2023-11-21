# BezierGraphics
# Instrukcja obsługi

## Bezier surface control points GROUPBOX
- Show Control Points radioButton - wyświetla punkry kontrolne powierzchni Beziera
- żeby zmienić wysokość punktu kontrolnego, wystarczy kliknąć w niego myszką i pociągnąć TrackBar.
- Label obok Trackbaru pokazuje wysokość wybranego punktu kontrolnego

## Triangle grid GROUPBOX
- Show triangle grid radioButton
- żeby zmienić dokładność triangulacji, wystarczy pociągnąć TrackBar.
- Label obok TrackBaru pokazuje bieżącą ilość trojkątów na jednej stronie Bitmap

## Light equation parameters GROUPBOX
- KD Value: TrackBar odpowiadający za wartość współczynnika KD w równaniu koloru
- KS Value: TrackBar odpowiadający za wartość współczynnika KS w równaniu koloru
- M Value: TrackBar odpowiadający za wartość współczynnika M w równaniu koloru

## Color of the object GROUPBOX
- Solid radioButton: po zaznaczeniu przy kliknięciu przycisku "Select..." można wybrać
kolor objektu
- Image radiobutton: po zaznaczeniu tło panelu jest wypełnieone obrazkiem.
Przy kliknięciu "Select..." można wgrać obrazek, który stanie się tłom.

## Light GROUPBOX
- Light movement: przy zaznaczeniu włącza się animacja światła.
- Wysokość światła ustawia się za pomocą TrackBar obok
- Label obok TrackBaru pokazuje bieżącą wysokość, na którym jest ustawione światło.
- Przy nacisnięciu "Select..." można wybrać kolor światła

## Normal Map GROUPBOX
- Normal map: przy zaznaczeniu kolory zostają przeliczone zgodniue z NormalMap
- Przy nacisnięciu "Select..." można wgrać nową Normal Map

## Domyślnie ustawione wartości:
- Wszyskie punkty kontrolne mają wysokość 0f
- Ilość trójkątów po jednej stronie Bitmap : 6
- Wartość współczynnika KD : 0.5f
- Wartość współczynnika KS : 0.5f
- Wartość współczynnika M : 30
- Domyślny kolor objektu: Solid Red (1f, 0f, 0f)
- Domyślny kolor światła : White (1f, 1f, 1f)
- Domyślna wysokość światła: 0.5f
- Domyślne koordynaty światła : (0.5f, 0.5f, 0.5f)