float4 mix(float4 a, float4 b, float amount) {
      return a * (1 - amount) + b * amount;
}

void rgb_to_hsv_float(float3 rgb, out float3 hsv) {
      float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
      float4 p = mix(float4(rgb.bg, K.wz), float4(rgb.gb, K.xy), step(rgb.b, rgb.g));
      float4 q = mix(float4(p.xyw, rgb.r), float4(rgb.r, p.yzx), step(p.x, rgb.r));

      float d = q.x - min(q.w, q.y);
      float e = 1.0e-10;
      hsv = float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
}

void hsv_to_rgb_float(float3 hsv, out float3 rgb) {
      float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
      float3 p = abs(frac(hsv.xxx + K.xyz) * 6.0 - K.www);

      rgb = hsv.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), hsv.y);
}

void quantise_float(float a, float steps, out float quantised) {
      quantised = floor(a * steps) / steps + (0.5 / steps);
}

void x_float(float _, out float3 Out) {
      Out = float3(1.0, 0.0, 0.0);
}
