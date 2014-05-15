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


using org.jbox2d.common;

namespace org.jbox2d.dynamics.contacts
{
    public class ContactVelocityConstraint
    {
        public readonly Mat22 K = new Mat22();
        public readonly Vec2 normal = new Vec2();
        public readonly Mat22 normalMass = new Mat22();
        public int contactIndex;
        public double friction;
        public int indexA;
        public int indexB;
        public double invIA, invIB;
        public double invMassA, invMassB;
        public int pointCount;
        public VelocityConstraintPoint[] points = new VelocityConstraintPoint[Settings.maxManifoldPoints];
        public double restitution;
        public double tangentSpeed;

        public ContactVelocityConstraint()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new VelocityConstraintPoint();
            }
        }
    }

    public class VelocityConstraintPoint
    {
        public readonly Vec2 rA = new Vec2();
        public readonly Vec2 rB = new Vec2();
        public double normalImpulse;
        public double normalMass;
        public double tangentImpulse;
        public double tangentMass;
        public double velocityBias;
    }
}