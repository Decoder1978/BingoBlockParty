/*******************************************************************************
 * Copyright (c) 2013, Daniel Murphy
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 * 	* Redistributions of source code must retain the above copyright notice,
 * 	  this list of conditions and the following disclaimer.
 * 	* Redistributions in binary form must reproduce the above copyright notice,
 * 	  this list of conditions and the following disclaimer in the documentation
 * 	  and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 * PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 ******************************************************************************/


/**
 * Global tuning constants based on MKS units and various int maximums (vertices per shape,
 * pairs, etc.).
 */

using System;

namespace org.jbox2d.common
{
    public class Settings
    {
        /** A "close to zero" double epsilon value for use */
        public static readonly double EPSILON = 1.1920928955078125E-7d;

        /** Pi. */
        public static readonly double PI = (double) Math.PI;

        // JBox2D specific settings
        public static bool FAST_ABS = true;
        public static bool FAST_FLOOR = true;
        public static bool FAST_CEIL = true;
        public static bool FAST_ROUND = true;
        public static bool FAST_ATAN2 = true;

        public static int CONTACT_STACK_INIT_SIZE = 10;
        public static bool SINCOS_LUT_ENABLED = true;
        /**
   * smaller the precision, the larger the table. If a small table is used (eg, precision is .006 or
   * greater), make sure you set the table to lerp it's results. Accuracy chart is in the MathUtils
   * source. Or, run the tests yourself in {@link SinCosTest}.</br> </br> Good lerp precision
   * values:
   * <ul>
   * <li>.0092</li>
   * <li>.008201</li>
   * <li>.005904</li>
   * <li>.005204</li>
   * <li>.004305</li>
   * <li>.002807</li>
   * <li>.001508</li>
   * <li>9.32500E-4</li>
   * <li>7.48000E-4</li>
   * <li>8.47000E-4</li>
   * <li>.0005095</li>
   * <li>.0001098</li>
   * <li>9.50499E-5</li>
   * <li>6.08500E-5</li>
   * <li>3.07000E-5</li>
   * <li>1.53999E-5</li>
   * </ul>
   */
        public static readonly double SINCOS_LUT_PRECISION = .00011d;
        public static readonly int SINCOS_LUT_LENGTH = (int) Math.Ceiling(Math.PI*2/SINCOS_LUT_PRECISION);
        /**
   * Use if the table's precision is large (eg .006 or greater). Although it is more expensive, it
   * greatly increases accuracy. Look in the MathUtils source for some test results on the accuracy
   * and speed of lerp vs non lerp. Or, run the tests yourself in {@link SinCosTest}.
   */
        public static bool SINCOS_LUT_LERP = false;


        // Collision

        /**
   * The maximum number of contact points between two convex shapes.
   */
        public static readonly int maxManifoldPoints = 2;

        /**
   * The maximum number of vertices on a convex polygon.
   */
        public static readonly int maxPolygonVertices = 8;

        /**
   * This is used to fatten AABBs in the dynamic tree. This allows proxies to move by a small amount
   * without triggering a tree adjustment. This is in meters.
   */
        public static readonly double aabbExtension = 0.1d;

        /**
   * This is used to fatten AABBs in the dynamic tree. This is used to predict the future position
   * based on the current displacement. This is a dimensionless multiplier.
   */
        public static readonly double aabbMultiplier = 2.0d;

        /**
   * A small length used as a collision and constraint tolerance. Usually it is chosen to be
   * numerically significant, but visually insignificant.
   */
        public static readonly double linearSlop = 0.005d;

        /**
   * A small angle used as a collision and constraint tolerance. Usually it is chosen to be
   * numerically significant, but visually insignificant.
   */
        public static readonly double angularSlop = (2.0d/180.0d*PI);

        /**
   * The radius of the polygon/edge shape skin. This should not be modified. Making this smaller
   * means polygons will have and insufficient for continuous collision. Making it larger may create
   * artifacts for vertex collision.
   */
        public static readonly double polygonRadius = (2.0d*linearSlop);

        /** Maximum number of sub-steps per contact in continuous physics simulation. */
        public static readonly int maxSubSteps = 8;

        // Dynamics

        /**
   * Maximum number of contacts to be handled to solve a TOI island.
   */
        public static readonly int maxTOIContacts = 32;

        /**
   * A velocity threshold for elastic collisions. Any collision with a relative linear velocity
   * below this threshold will be treated as inelastic.
   */
        public static readonly double velocityThreshold = 1.0d;

        /**
   * The maximum linear position correction used when solving constraints. This helps to prevent
   * overshoot.
   */
        public static readonly double maxLinearCorrection = 0.2d;

        /**
   * The maximum angular position correction used when solving constraints. This helps to prevent
   * overshoot.
   */
        public static readonly double maxAngularCorrection = (8.0d/180.0d*PI);

        /**
   * The maximum linear velocity of a body. This limit is very large and is used to prevent
   * numerical problems. You shouldn't need to adjust this.
   */
        public static readonly double maxTranslation = 2.0d;
        public static readonly double maxTranslationSquared = (maxTranslation*maxTranslation);

        /**
   * The maximum angular velocity of a body. This limit is very large and is used to prevent
   * numerical problems. You shouldn't need to adjust this.
   */
        public static readonly double maxRotation = (0.5d*PI);
        public static double maxRotationSquared = (maxRotation*maxRotation);

        /**
   * This scale factor controls how fast overlap is resolved. Ideally this would be 1 so that
   * overlap is removed in one time step. However using values close to 1 often lead to overshoot.
   */
        public static readonly double baumgarte = 0.2d;
        public static readonly double toiBaugarte = 0.75d;


        // Sleep

        /**
   * The time that a body must be still before it will go to sleep.
   */
        public static readonly double timeToSleep = 0.5d;

        /**
   * A body cannot sleep if its linear velocity is above this tolerance.
   */
        public static readonly double linearSleepTolerance = 0.01d;

        /**
   * A body cannot sleep if its angular velocity is above this tolerance.
   */
        public static readonly double angularSleepTolerance = (2.0d/180.0d*PI);

        /**
   * Friction mixing law. Feel free to customize this. TODO djm: add customization
   * 
   * @param friction1
   * @param friction2
   * @return
   */

        public static double mixFriction(double friction1, double friction2)
        {
            return MathUtils.sqrt(friction1*friction2);
        }

        /**
   * Restitution mixing law. Feel free to customize this. TODO djm: add customization
   * 
   * @param restitution1
   * @param restitution2
   * @return
   */

        public static double mixRestitution(double restitution1, double restitution2)
        {
            return restitution1 > restitution2 ? restitution1 : restitution2;
        }
    }
}