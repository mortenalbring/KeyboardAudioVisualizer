﻿using KeyboardAudioVisualizer.AudioProcessing.VisualizationProvider;
using RGB.NET.Core;

namespace KeyboardAudioVisualizer.Decorators
{
    public class BeatDecorator : AbstractUpdateAwareDecorator, IBrushDecorator
    {
        #region Properties & Fields

        private readonly IVisualizationProvider _visualizationProvider;

        #endregion

        #region Constructors

        public BeatDecorator(IVisualizationProvider visualizationProvider)
        {
            this._visualizationProvider = visualizationProvider;
        }

        #endregion

        #region Methods

        protected override void Update(double deltaTime) => _visualizationProvider.Update();

        public void ManipulateColor(Rectangle rectangle, BrushRenderTarget renderTarget, ref Color color)
        {
            color.APercent *= _visualizationProvider.VisualizationData[0];
        }

        #endregion
    }
}
