﻿using graf3d.Engine.Algorytmy;
using graf3d.Engine.Struktury;

namespace graf3d.Engine.Oświetlenie
{
    /// <summary>
    ///     Klasa reprezentująca "tworzywo" z jakiego jest wykonany model.
    /// </summary>
    public class Material
    {
        private readonly NormalMap _normalMap = new NormalMap(@"rock.png");

        /// <summary>
        ///     Współczynnik wypukłości. Reguluje
        /// </summary>
        public float BumpFactor { get; set; } = 0.1f;

        /// <summary>
        ///     Oświetlenie emisyjne, to światło, które jest emitowane przez obiekt. Na przykład znak neonowy.
        /// </summary>
        public Color Emissive { get; set; }

        /// <summary>
        ///     Ambient to bazowy kolor dodawany do wszystkich powierzchni.
        /// </summary>
        public Color Ambient { get; set; }

        /// <summary>
        ///     Diffuse to światło odbijane pod różnymi kątami zamiast tylko jednego kąta tak jak Specular.
        /// </summary>
        public Color Diffuse { get; set; }

        /// <summary>
        ///     Specular to światło odbijane tylko pod jednym kątem, tworzy błyszczący punkt na powierzchni obiektu.
        /// </summary>
        public Color Specular { get; set; }

        /// <summary>
        ///     Liczba zmiennoprzecinkowa określająca ostrość oświetlenia Specular. Im wyższa wartość, tym ostrzejszy punkt.
        ///     Zakres wartości wynosi od 0 do +nieskończoności.
        /// </summary>
        public float Shininess { get; set; }

        /// <summary>
        ///     Sposób wyliczania odbicia kierunkowego. Tutaj domyślnie metoda Blinn-Phonga.
        /// </summary>
        public ISpecularReflectionAlgorithm SpecularAlgorithm { get; } = new BlinnPhongSpecularAlgorithm();

        /// <summary>
        ///     Metoda mapująca wektor normalny. Służy dodawaniu nierówności oświetlenia.
        /// </summary>
        public Vector3 MapNormal(int x, int y, Vector3 normal)
        {
            var r = BumpFactor;
            var q1 = normal;
            var q2 = _normalMap[x, y];
            return q1*(1 - r) + q2*r;
        }
    }
}